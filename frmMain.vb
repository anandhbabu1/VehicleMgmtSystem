Public Class frmMain
    Dim frmObj As Form
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strTitle + " - [" + strLogUsrName + "]"
        Me.IsMdiContainer = True
        menuStrip1.BackColor = Color.LightBlue
        menuStrip1.ForeColor = Color.Black
        menuStrip1.Font = New Font("Calibri", 10)

    End Sub

    Private Sub vendorInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles vendorInfoToolStripMenuItem.Click
        frmObj = New frmCompanySetup

        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub

    Private Sub userConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles userConfigurationToolStripMenuItem.Click
        frmObj = New frmUserConfig
        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub

    Private Sub PasswordResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordResetToolStripMenuItem.Click
        frmObj = New frmPwdReset
        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub

    Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub dataEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles dataEntryToolStripMenuItem.Click
        frmObj = New frmVisitorEntry
        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub

    Private Sub reportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles reportsToolStripMenuItem.Click
        frmObj = New frmSearch
        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub
End Class