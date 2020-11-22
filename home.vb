
Imports System.Threading
Imports CefSharp
Imports CefSharp.OffScreen
Imports System.Data.SqlClient

Public Class Photographer
    Private stopRequested As Boolean = False
    Private WithEvents browser As ChromiumWebBrowser
    Private ConString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Desktop\freelancer\siteCapture\siteCapture\default.mdf;Integrated Security=True;Connect Timeout=30"
    Delegate Sub UpdateOutText(text As String)
    Delegate Sub DelUpdateStartButton()
    Private SiteNow As New curruntSite()

    Private siteInEdit As Integer = 0
    Private outDirectory As String = ""

#Region "Site Capture Execution"

    Private Sub ProcessNextItem()
        If stopRequested = False Then
            Using conn = New SqlConnection(ConString)
                Using Command As New SqlCommand("SELECT TOP 1 @id = id, @sitename = sitename,@url = url,@cbox_id =  ISNULL(cb_id,''),@cbox_class = ISNULL(cb_class,'') FROM tab_site WHERE completed = 0 ORDER BY Id ASC", conn)
                    Command.CommandType = CommandType.Text
                    Command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output
                    Command.Parameters.Add("@sitename", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output
                    Command.Parameters.Add("@url", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output
                    Command.Parameters.Add("@cbox_id", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output
                    Command.Parameters.Add("@cbox_class", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output
                    conn.Open()
                    Command.ExecuteNonQuery()
                    If Command.Parameters("@id") IsNot Nothing Then
                        SiteNow.siteid = Command.Parameters("@id").Value
                        SiteNow.siteName = Command.Parameters("@sitename").Value
                        SiteNow.url = Command.Parameters("@url").Value
                        SiteNow.cb_id = Command.Parameters("@cbox_id").Value
                        SiteNow.cb_class = Command.Parameters("@cbox_class").Value
                        SetOutput("Loading URL " + SiteNow.siteName)
                        browser.Load(SiteNow.url)
                    Else
                        SetOutput("No More Rows to capture. Stopping...")
                    End If
                End Using
            End Using
        Else
            UpdateStartButton()
        End If
    End Sub

    Public Class curruntSite
        Public Property siteid As Integer
        Public Property siteName As String
        Public Property url As String
        Public Property cb_id As String
        Public Property cb_class As String
    End Class

    Private Sub BrowserInitialiseComplete(ByVal sender As Object, ByVal e As EventArgs) Handles browser.BrowserInitialized
        SetOutput("Browser Initialization Complete")
        ProcessNextItem()
    End Sub

    Private Sub BrowserLoadComplete(ByVal sender As Object, ByVal e As LoadingStateChangedEventArgs) Handles browser.LoadingStateChanged
        If e.IsLoading = False Then
            SetOutput("Loading complete for site" + SiteNow.siteName)
            RemoveCookieBox()
        End If
    End Sub

    Private Async Sub RemoveCookieBox()
        If (SiteNow.cb_id = "" And SiteNow.cb_class = "") Then
            findKeyForSite()
            SaveScreenShoot()
        ElseIf SiteNow.cb_id.Length > 0 Then
            Dim script As String = "(function () {
                try {
                    let element = document.getElementById('" + SiteNow.cb_id + "')
                    if (element !== undefined) {
                        element.remove();
                    }
                    console.log('Removal done');
                } catch (error) {
                    console.log(error);
                }
                return true
            })()"
            Dim result = Await browser.EvaluateScriptAsync(script)
            SaveScreenShoot()
        ElseIf SiteNow.cb_class.Length > 0 Then
            Dim script As String = "
            (function () {
                try {
                    let element = document.getElementsByClassName('" + SiteNow.cb_class + "')
                    if (element !== undefined) {
                        element[0].remove();
                        console.log('Removal done')
                    }
                } catch (error) {
                    console.log(error);
                }
                return true
            })()"
            Dim result = Await browser.EvaluateScriptAsync(script)
            SaveScreenShoot()
        End If
    End Sub

    Public Async Sub SaveScreenShoot()
        Dim script As String = "console.log('Taking Screenshoot');"
        Dim fileName As String = ""
        Dim result = Await browser.EvaluateScriptAsync(script)
        Thread.Sleep(500)
        Try
            Using capture = browser.ScreenshotOrNull()
                fileName = "Image-" + SiteNow.siteName + "-" + Now.ToString("dd-MM-yyyy") + ".bmp"
                capture.Save(outDirectory + fileName)

            End Using
        Catch ex As Exception
            SetOutput(ex.Message)
        End Try
        SetOutput("Image " + fileName + " Saved Successfully")
        Using conn = New SqlConnection(ConString)
            Using Command As New SqlCommand("UPDATE tab_site SET completed = 1 WHERE id = @id", conn)
                Command.CommandType = CommandType.Text
                Command.Parameters.AddWithValue("@id", SiteNow.siteid)
                conn.Open()
                Command.ExecuteNonQuery()
            End Using
        End Using
        ProcessNextItem()
    End Sub

    Private Sub InitialiseBrowser()
        Dim settings As New CefSettings()
        settings.CefCommandLineArgs.Add("--remote-debugging-port", "8088")
        settings.CefCommandLineArgs.Add("--multi-threaded-message-loop", "true")
        CefSharp.Cef.Initialize(settings)
        browser = New ChromiumWebBrowser()
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        If btn_start.Text = "Start" Then
            If outDirectory = "" Then
                MsgBox("Please select output directory")
            Else
                btn_start.Text = "Stop"
                lvl_out_directory.Enabled = False
                SetOutput("Starting Application")
                GenrateKeyIndex()
                InitialiseBrowser()
            End If
        Else
            stopRequested = True
            SetOutput("Stopping Requested Will be stopped after saving the currunt image")
            btn_start.Text = "Stopping.."
            btn_start.Enabled = False
        End If
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        Using conn = New SqlConnection(ConString)
            Using Command As New SqlCommand("UPDATE tab_site SET completed = 0", conn)
                Command.CommandType = CommandType.Text
                conn.Open()
                Command.ExecuteNonQuery()
                SetOutput("Reset Done....")
            End Using
        End Using
    End Sub

#End Region

    Private Sub GenrateKeyIndex()
        SetOutput("Updating Keys data")
        Try
            Using conn = New SqlConnection(ConString)
                Using Command As New SqlCommand("sp_keydata_update", conn)
                    Command.CommandType = CommandType.StoredProcedure
                    conn.Open()
                    Command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
        SetOutput("Updating Keys data Completed")
    End Sub

    Private Async Sub findKeyForSite()
        Dim dbRowOffset = 0
        Dim foundId As Boolean = False
        Dim textString = ""
        Dim result As JavascriptResponse
        'Find if matching id is present
        textString = getIdsKeyData(dbRowOffset)
        While textString <> ""
            Dim script As String = "(function (idsString) {
            let ids
            try {
                ids = idsString.split(',')
                let curruntId = 'False'
                ids.every(id => {
                    let element = document.getElementById(id)
                    if (element) {
                        curruntId = id
                        element.remove();
                        console.log('Removal done')
                        return false
                    }
                    return true
                });
                return curruntId
            } catch (error) {
                console.log(error);
            }
            return 'False'
        })('" + textString + "')"
            result = Await browser.EvaluateScriptAsync(script)
            If result.Result = "False" Or result.Result Is Nothing Then
                SetOutput("No Element id matched in currunt batch found for site" + SiteNow.siteName)
                dbRowOffset = dbRowOffset + 20
                textString = getIdsKeyData(dbRowOffset)
            Else
                SetOutput("Matching Element id " + result.Result + " found for site " + SiteNow.siteName)
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("Update tab_site SET cb_id = @idname WHERE Id = @id", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@id", SiteNow.siteid)
                        Command.Parameters.AddWithValue("@idname", result.Result)
                        conn.Open()
                        Command.ExecuteNonQuery()
                    End Using
                End Using
                Exit While
            End If
        End While

        'if id not found then check if matching class is present
        If Not foundId Then
            SetOutput("Element id not matched for site " + SiteNow.siteName + "Trying classes now")
            dbRowOffset = 0
            textString = getClasssKeyData(dbRowOffset)
            While textString <> ""
                Dim script As String = "(function (classString) {
                    let ids
                    try {
                        ids = classString.split(',')
                        let curruntId = 'False'
                        ids.every(id => {
                            let element = document.getElementsByClassName(id)
                            if (element.length > 0) {
                                curruntId = id
                                element[0].remove();
                                console.log('Removal done')
                                return false
                            }
                            return true
                        });
                        return curruntId
                    } catch (error) {
                        console.log(error);
                    }
                    return 'False'
                })('" + textString + "')"
                result = Await browser.EvaluateScriptAsync(script)
                If result.Result = "False" Or result.Result Is Nothing Then
                    SetOutput("No Class matched in currunt batch found for site" + SiteNow.siteName)
                    dbRowOffset = dbRowOffset + 20
                    textString = getIdsKeyData(dbRowOffset)
                Else
                    SetOutput("Matching class " + result.Result + "found for site" + SiteNow.siteName)
                    Using conn = New SqlConnection(ConString)
                        Using Command As New SqlCommand("Update tab_site SET cb_class = @idname WHERE Id = @id", conn)
                            Command.CommandType = CommandType.Text
                            Command.Parameters.AddWithValue("@id", SiteNow.siteid)
                            Command.Parameters.AddWithValue("@idname", result.Result)
                            conn.Open()
                            Command.ExecuteNonQuery()
                        End Using
                    End Using
                    Exit While
                End If
            End While

        End If



    End Sub


    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateSiteGv()
    End Sub

    Private Function getIdsKeyData(ByVal dbRowOffset As Integer) As String
        Dim textString = ""
        Try
            Using dt = New DataTable()
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("SELECT id_name FROM tab_ids ORDER BY id_useCount DESC OFFSET @offset ROWS FETCH NEXT 20 ROWS ONLY", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@offset", dbRowOffset)
                        conn.Open()
                        dt.Load(Command.ExecuteReader())
                    End Using
                End Using
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If textString = "" Then
                            textString = textString + row(0)
                        Else
                            textString = textString + "," + row(0)
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
            SetOutput("SQL ERROR " + ex.Message)
        End Try
        Return textString
    End Function

    Private Function getClasssKeyData(ByVal dbRowOffset As Integer) As String
        Dim textString = ""
        Try
            Using dt = New DataTable()
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("SELECT class_name FROM tab_class ORDER BY class_useCount DESC OFFSET @offset ROWS FETCH NEXT 20 ROWS ONLY", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@offset", dbRowOffset)
                        conn.Open()
                        dt.Load(Command.ExecuteReader())
                    End Using
                End Using
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If textString = "" Then
                            textString = textString + row(0)
                        Else
                            textString = textString + "," + row(0)
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
            SetOutput("SQL ERROR " + ex.Message)
        End Try
        Return textString
    End Function

#Region "Site Gridview and subsystem"
    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        PopulateSiteGv()
    End Sub

    Private Sub PopulateSiteGv()
        Try
            Using dt As New DataTable
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("SELECT id,sitename,url,cb_id,cb_class,completed FROM tab_site WHERE @term = '' OR (sitename like '%'+@term+'%' OR url like '%'+@term+'%' OR cb_id like '%'+@term+'%' OR cb_class like '%'+@term+'%' )", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@term", txt_findsite.Text)
                        conn.Open()
                        dt.Load(Command.ExecuteReader())
                    End Using
                End Using
                If dt.Rows.Count > 0 Then
                    gv_sites.DataSource = dt
                    gv_sites.ClearSelection()
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub


    Private Sub gv_sites_SelectionChanged(sender As Object, e As EventArgs) Handles gv_sites.SelectionChanged
        siteInEdit = gv_sites.SelectedRows(0).Cells(0).Value
        txt_site_name.Text = gv_sites.SelectedRows(0).Cells(1).Value
        txt_site_url.Text = gv_sites.SelectedRows(0).Cells(2).Value
        txt_element_id.Text = gv_sites.SelectedRows(0).Cells(3).Value
        txt_element_class.Text = gv_sites.SelectedRows(0).Cells(4).Value
    End Sub

    Private Sub btn_form_reset_Click(sender As Object, e As EventArgs) Handles btn_form_reset.Click
        siteInEdit = 0
        txt_site_url.Text = ""
        txt_site_name.Text = ""
        txt_element_id.Text = ""
        txt_element_class.Text = ""
    End Sub


    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txt_site_name.Text = "" Or txt_site_url.Text = "" Then
            MsgBox("Site name and URL is Mendatory field")
        Else
            If siteInEdit = 0 Then
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("INSERT INTO tab_site (sitename,url,cb_id,cb_class,completed) VALUES(@sitename,@url,@cb_id,@cb_class,0)", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@sitename", txt_site_name.Text)
                        Command.Parameters.AddWithValue("@url", txt_site_url.Text)
                        Command.Parameters.AddWithValue("@cb_id", txt_element_id.Text)
                        Command.Parameters.AddWithValue("@cb_class", txt_element_class.Text)
                        conn.Open()
                        Command.ExecuteNonQuery()
                    End Using
                End Using
            Else
                Using conn = New SqlConnection(ConString)
                    Using Command As New SqlCommand("UPDATE tab_site SET sitename = @sitename , url = @url,cb_id = @cb_id,cb_class = @cb_class WHERE Id = @id", conn)
                        Command.CommandType = CommandType.Text
                        Command.Parameters.AddWithValue("@sitename", txt_site_name.Text)
                        Command.Parameters.AddWithValue("@url", txt_site_url.Text)
                        Command.Parameters.AddWithValue("@cb_id", txt_element_id.Text)
                        Command.Parameters.AddWithValue("@cb_class", txt_element_class.Text)
                        Command.Parameters.AddWithValue("@id", siteInEdit)
                        conn.Open()
                        Command.ExecuteNonQuery()
                    End Using
                End Using
            End If
            btn_form_reset.PerformClick()
            PopulateSiteGv()
        End If

    End Sub


    Private Sub btn_delete_site_Click(sender As Object, e As EventArgs) Handles btn_delete_site.Click
        If siteInEdit = 0 Then
            MsgBox("Select a site to delete")
        Else
            Using conn = New SqlConnection(ConString)
                Using Command As New SqlCommand("DELETE tab_site WHERE Id = @id", conn)
                    Command.CommandType = CommandType.Text
                    Command.Parameters.AddWithValue("@id", siteInEdit)
                    conn.Open()
                    Command.ExecuteNonQuery()
                End Using
            End Using
            btn_form_reset.PerformClick()
            PopulateSiteGv()
        End If
    End Sub


    Private Sub gv_sites_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles gv_sites.DataBindingComplete
        gv_sites.ClearSelection()
    End Sub


    Private Sub txt_findsite_TextChanged(sender As Object, e As EventArgs) Handles txt_findsite.TextChanged
        If txt_findsite.Text.Length > 2 Then
            PopulateSiteGv()
        ElseIf txt_findsite.Text.Length = 0 Then
            PopulateSiteGv()
        End If
    End Sub


#End Region

#Region "deligate"
    Private Sub WriteOutputText(text As String)
        If txt_output.InvokeRequired Then
            Dim d As New UpdateOutText(AddressOf SetOutput)
            txt_output.Invoke(d, New Object() {text})
        Else
            txt_output.AppendText(Now.ToString + " " + text)
            txt_output.AppendText(Environment.NewLine)
        End If
    End Sub

    Private Sub SetOutput(ByVal text As String)
        WriteOutputText(text)
    End Sub


    Private Sub UpdateStartButton()
        If txt_output.InvokeRequired Then
            Dim d As New UpdateOutText(AddressOf SetStartButton)
            btn_start.Invoke(d, New Object() {Text})
            lvl_out_directory.Invoke(d, New Object() {Text})
        Else
            btn_start.Text = "Start"
            btn_start.Enabled = True
            lvl_out_directory.Enabled = True
        End If
    End Sub

    Private Sub SetStartButton()
        UpdateStartButton()
    End Sub
#End Region

    Private Sub lvl_out_directory_Click(sender As Object, e As EventArgs) Handles lvl_out_directory.Click
        Using frm = New FolderBrowserDialog()
            If frm.ShowDialog(Me) = DialogResult.OK Then
                outDirectory = frm.SelectedPath + "\"
                lvl_out_directory.Text = "Saving To :" + frm.SelectedPath
            End If
        End Using
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Application.Exit()
    End Sub


End Class