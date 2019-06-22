Imports System.Configuration
Imports System.Data.OleDb
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sLoadSettings()
    End Sub
    Private Sub sLoadSettings()
        Dim dsSettings As New DataSet
        Dim dtSettings As New DataTable
        Try
            dsSettings.ReadXml("settings.xml")
            dtSettings = dsSettings.Tables("settings")
            strTitle = dtSettings.Rows(0).Item("header")
            lblHeading.Text = strTitle
            strDbName = dtSettings.Rows(0).Item("dbname")

            strCopyYear = dtSettings.Rows(0).Item("copyyear")
            strCompanyName = dtSettings.Rows(0).Item("companyname")
            strVersion = dtSettings.Rows(0).Item("version")

            lblCopyright.Text = "Version - [" + strVersion + "] (c) " + strCopyYear + " All rights reserved"

            strDbPath = Application.StartupPath + "\" + strDbName
            strDbConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strDbPath + "; Persist Security Info = False; "
        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub sValidateLogin()
        Dim oleConn As OleDbConnection
        Dim dtUser As New DataTable
        Dim oleAda As OleDbDataAdapter
        Dim strSQL As String
        Try


            oleConn = New OleDbConnection(strDbConnect)

            If txtUserId.Text.ToString().Trim() = "" Then
                MessageBox.Show("User id required to connect", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If txtPassword.Text.ToString().Trim() = "" Then
                MessageBox.Show("Password required to connect", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If


            strSQL = "SELECT User_id, user_name FROM user_info WHERE USER_ID='" + txtUserId.Text.Trim() + "' AND PASSWORD='" + txtPassword.Text.Trim() + "'"
            oleAda = New OleDbDataAdapter(strSQL, oleConn)
            oleAda.Fill(dtUser)

            If (dtUser.Rows.Count > 0) Then
                strloguser = txtUserId.Text
                strLogUsrName = dtUser.Rows(0).Item("user_name")
                Dim frmM As New frmMain
                frmM.StartPosition = FormStartPosition.CenterScreen
                frmM.Show()
                Me.Close()
            Else
                MessageBox.Show("User ID or Password does not match", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        sValidateLogin()
    End Sub

    Private Sub lnkPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPassword.LinkClicked
        Dim oleConn As OleDbConnection
        Dim dtUser As New DataTable
        Dim oleAda As OleDbDataAdapter
        Dim strSQL As String

        oleConn = New OleDbConnection(strDbConnect)

        If txtUserId.Text.ToString().Trim() = "" Then
            MessageBox.Show("User id required to set/reset password", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        strSQL = "SELECT User_id FROM user_info WHERE USER_ID='" + txtUserId.Text.Trim() + "'"
        oleAda = New OleDbDataAdapter(strSQL, oleConn)
        oleAda.Fill(dtUser)

        If (dtUser.Rows.Count > 0) Then
            strloguser = txtUserId.Text
            Dim frmM As New frmPwdReset
            frmM.blnFrom = True
            frmM.Show()

        Else
            MessageBox.Show("User ID does not exists in the sytem", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtUserId_TextChanged(sender As Object, e As EventArgs) Handles txtUserId.TextChanged
        txtPassword.Text = ""
    End Sub
End Class
