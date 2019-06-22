<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.vendorInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dataEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.userConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpiryMonthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainToolStripMenuItem, Me.optionsToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.menuStrip1.Size = New System.Drawing.Size(914, 24)
        Me.menuStrip1.TabIndex = 1
        Me.menuStrip1.Text = "menuStrip1"
        '
        'mainToolStripMenuItem
        '
        Me.mainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.vendorInfoToolStripMenuItem, Me.dataEntryToolStripMenuItem, Me.reportsToolStripMenuItem, Me.exitToolStripMenuItem})
        Me.mainToolStripMenuItem.Name = "mainToolStripMenuItem"
        Me.mainToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.mainToolStripMenuItem.Text = "Main"
        '
        'vendorInfoToolStripMenuItem
        '
        Me.vendorInfoToolStripMenuItem.Name = "vendorInfoToolStripMenuItem"
        Me.vendorInfoToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.vendorInfoToolStripMenuItem.Text = "Company Setup"
        '
        'dataEntryToolStripMenuItem
        '
        Me.dataEntryToolStripMenuItem.Name = "dataEntryToolStripMenuItem"
        Me.dataEntryToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.dataEntryToolStripMenuItem.Text = "Visitor Details"
        '
        'reportsToolStripMenuItem
        '
        Me.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem"
        Me.reportsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.reportsToolStripMenuItem.Text = "Search"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.exitToolStripMenuItem.Text = "Exit"
        '
        'optionsToolStripMenuItem
        '
        Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.userConfigurationToolStripMenuItem, Me.PasswordResetToolStripMenuItem, Me.ExpiryMonthToolStripMenuItem})
        Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
        Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.optionsToolStripMenuItem.Text = "Settings"
        '
        'userConfigurationToolStripMenuItem
        '
        Me.userConfigurationToolStripMenuItem.Name = "userConfigurationToolStripMenuItem"
        Me.userConfigurationToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.userConfigurationToolStripMenuItem.Text = "User Creation"
        '
        'PasswordResetToolStripMenuItem
        '
        Me.PasswordResetToolStripMenuItem.Name = "PasswordResetToolStripMenuItem"
        Me.PasswordResetToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.PasswordResetToolStripMenuItem.Text = "Password Reset"
        '
        'ExpiryMonthToolStripMenuItem
        '
        Me.ExpiryMonthToolStripMenuItem.Name = "ExpiryMonthToolStripMenuItem"
        Me.ExpiryMonthToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExpiryMonthToolStripMenuItem.Text = "Expiry Month"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(914, 704)
        Me.Controls.Add(Me.menuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents mainToolStripMenuItem As ToolStripMenuItem
    Private WithEvents vendorInfoToolStripMenuItem As ToolStripMenuItem
    Private WithEvents dataEntryToolStripMenuItem As ToolStripMenuItem
    Private WithEvents reportsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
    Private WithEvents optionsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents userConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasswordResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpiryMonthToolStripMenuItem As ToolStripMenuItem
End Class
