<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Photographer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Photographer))
        Me.bw_SaveScreenShoot = New System.ComponentModel.BackgroundWorker()
        Me.txt_output = New System.Windows.Forms.TextBox()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.bw_updateOutText = New System.ComponentModel.BackgroundWorker()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.gv_sites = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sitename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.siteurl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb_class = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.completed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.txt_site_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_site_url = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_element_id = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_element_class = New System.Windows.Forms.TextBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_form_reset = New System.Windows.Forms.Button()
        Me.btn_delete_site = New System.Windows.Forms.Button()
        Me.lvl_out_directory = New System.Windows.Forms.Label()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.txt_findsite = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.gv_sites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_output
        '
        Me.txt_output.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_output.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_output.ForeColor = System.Drawing.Color.Chartreuse
        Me.txt_output.Location = New System.Drawing.Point(1072, 12)
        Me.txt_output.Multiline = True
        Me.txt_output.Name = "txt_output"
        Me.txt_output.ReadOnly = True
        Me.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_output.Size = New System.Drawing.Size(820, 905)
        Me.txt_output.TabIndex = 0
        '
        'btn_start
        '
        Me.btn_start.CausesValidation = False
        Me.btn_start.Location = New System.Drawing.Point(1817, 923)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(75, 66)
        Me.btn_start.TabIndex = 3
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'btn_reset
        '
        Me.btn_reset.CausesValidation = False
        Me.btn_reset.Location = New System.Drawing.Point(1716, 923)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(75, 66)
        Me.btn_reset.TabIndex = 4
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseVisualStyleBackColor = True
        '
        'gv_sites
        '
        Me.gv_sites.AllowUserToAddRows = False
        Me.gv_sites.AllowUserToDeleteRows = False
        Me.gv_sites.AllowUserToResizeRows = False
        Me.gv_sites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gv_sites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_sites.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.sitename, Me.siteurl, Me.cb_id, Me.cb_class, Me.completed})
        Me.gv_sites.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gv_sites.Location = New System.Drawing.Point(13, 13)
        Me.gv_sites.MultiSelect = False
        Me.gv_sites.Name = "gv_sites"
        Me.gv_sites.ReadOnly = True
        Me.gv_sites.RowHeadersVisible = False
        Me.gv_sites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gv_sites.Size = New System.Drawing.Size(1053, 697)
        Me.gv_sites.TabIndex = 5
        Me.gv_sites.TabStop = False
        '
        'id
        '
        Me.id.DataPropertyName = "Id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'sitename
        '
        Me.sitename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.sitename.DataPropertyName = "sitename"
        Me.sitename.FillWeight = 20.0!
        Me.sitename.HeaderText = "Name"
        Me.sitename.Name = "sitename"
        Me.sitename.ReadOnly = True
        '
        'siteurl
        '
        Me.siteurl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.siteurl.DataPropertyName = "url"
        Me.siteurl.FillWeight = 50.0!
        Me.siteurl.HeaderText = "URL"
        Me.siteurl.Name = "siteurl"
        Me.siteurl.ReadOnly = True
        '
        'cb_id
        '
        Me.cb_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cb_id.DataPropertyName = "cb_id"
        Me.cb_id.FillWeight = 10.0!
        Me.cb_id.HeaderText = "ID"
        Me.cb_id.Name = "cb_id"
        Me.cb_id.ReadOnly = True
        '
        'cb_class
        '
        Me.cb_class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cb_class.DataPropertyName = "cb_class"
        Me.cb_class.FillWeight = 10.0!
        Me.cb_class.HeaderText = "Class"
        Me.cb_class.Name = "cb_class"
        Me.cb_class.ReadOnly = True
        '
        'completed
        '
        Me.completed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.completed.DataPropertyName = "completed"
        Me.completed.FillWeight = 10.0!
        Me.completed.HeaderText = "Completed"
        Me.completed.Name = "completed"
        Me.completed.ReadOnly = True
        '
        'btn_refresh
        '
        Me.btn_refresh.CausesValidation = False
        Me.btn_refresh.Location = New System.Drawing.Point(991, 716)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(75, 66)
        Me.btn_refresh.TabIndex = 6
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'txt_site_name
        '
        Me.txt_site_name.Location = New System.Drawing.Point(107, 740)
        Me.txt_site_name.Name = "txt_site_name"
        Me.txt_site_name.Size = New System.Drawing.Size(194, 20)
        Me.txt_site_name.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 741)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Site Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 717)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Site URL"
        '
        'txt_site_url
        '
        Me.txt_site_url.Location = New System.Drawing.Point(107, 716)
        Me.txt_site_url.Name = "txt_site_url"
        Me.txt_site_url.Size = New System.Drawing.Size(360, 20)
        Me.txt_site_url.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 769)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Element ID"
        '
        'txt_element_id
        '
        Me.txt_element_id.Location = New System.Drawing.Point(107, 768)
        Me.txt_element_id.Name = "txt_element_id"
        Me.txt_element_id.Size = New System.Drawing.Size(194, 20)
        Me.txt_element_id.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 795)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Class"
        '
        'txt_element_class
        '
        Me.txt_element_class.Location = New System.Drawing.Point(107, 794)
        Me.txt_element_class.Name = "txt_element_class"
        Me.txt_element_class.Size = New System.Drawing.Size(194, 20)
        Me.txt_element_class.TabIndex = 13
        '
        'btn_save
        '
        Me.btn_save.CausesValidation = False
        Me.btn_save.Location = New System.Drawing.Point(392, 742)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 72)
        Me.btn_save.TabIndex = 15
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_form_reset
        '
        Me.btn_form_reset.CausesValidation = False
        Me.btn_form_reset.Location = New System.Drawing.Point(311, 742)
        Me.btn_form_reset.Name = "btn_form_reset"
        Me.btn_form_reset.Size = New System.Drawing.Size(75, 72)
        Me.btn_form_reset.TabIndex = 16
        Me.btn_form_reset.Text = "Reset"
        Me.btn_form_reset.UseVisualStyleBackColor = True
        '
        'btn_delete_site
        '
        Me.btn_delete_site.CausesValidation = False
        Me.btn_delete_site.Location = New System.Drawing.Point(529, 716)
        Me.btn_delete_site.Name = "btn_delete_site"
        Me.btn_delete_site.Size = New System.Drawing.Size(75, 98)
        Me.btn_delete_site.TabIndex = 17
        Me.btn_delete_site.Text = "Delete"
        Me.btn_delete_site.UseVisualStyleBackColor = True
        '
        'lvl_out_directory
        '
        Me.lvl_out_directory.AutoSize = True
        Me.lvl_out_directory.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_out_directory.Location = New System.Drawing.Point(10, 843)
        Me.lvl_out_directory.Name = "lvl_out_directory"
        Me.lvl_out_directory.Size = New System.Drawing.Size(194, 17)
        Me.lvl_out_directory.TabIndex = 20
        Me.lvl_out_directory.Text = "Click to select output path"
        '
        'btn_exit
        '
        Me.btn_exit.CausesValidation = False
        Me.btn_exit.Location = New System.Drawing.Point(12, 923)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 66)
        Me.btn_exit.TabIndex = 21
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'txt_findsite
        '
        Me.txt_findsite.Location = New System.Drawing.Point(685, 719)
        Me.txt_findsite.Name = "txt_findsite"
        Me.txt_findsite.Size = New System.Drawing.Size(272, 20)
        Me.txt_findsite.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(642, 719)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Find"
        '
        'Photographer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_findsite)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.lvl_out_directory)
        Me.Controls.Add(Me.btn_delete_site)
        Me.Controls.Add(Me.btn_form_reset)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_element_class)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_element_id)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_site_url)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_site_name)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.gv_sites)
        Me.Controls.Add(Me.btn_reset)
        Me.Controls.Add(Me.btn_start)
        Me.Controls.Add(Me.txt_output)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1038)
        Me.Name = "Photographer"
        Me.Text = "home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gv_sites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bw_SaveScreenShoot As System.ComponentModel.BackgroundWorker
    Friend WithEvents txt_output As TextBox
    Friend WithEvents btn_start As Button
    Friend WithEvents bw_updateOutText As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_reset As Button
    Friend WithEvents gv_sites As DataGridView
    Friend WithEvents btn_refresh As Button
    Friend WithEvents txt_site_name As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_site_url As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_element_id As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_element_class As TextBox
    Friend WithEvents btn_save As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents sitename As DataGridViewTextBoxColumn
    Friend WithEvents siteurl As DataGridViewTextBoxColumn
    Friend WithEvents cb_id As DataGridViewTextBoxColumn
    Friend WithEvents cb_class As DataGridViewTextBoxColumn
    Friend WithEvents completed As DataGridViewCheckBoxColumn
    Friend WithEvents btn_form_reset As Button
    Friend WithEvents btn_delete_site As Button
    Friend WithEvents lvl_out_directory As Label
    Friend WithEvents btn_exit As Button
    Friend WithEvents txt_findsite As TextBox
    Friend WithEvents Label5 As Label
End Class
