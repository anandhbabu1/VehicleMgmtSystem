Imports System.Data.OleDb

Public Class frmPwdReset
    Public blnFrom As Boolean = False
    Private Sub frmPwdReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strTitle + " - [Password Reset]"
        If blnFrom Then
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
        blnFrom = False
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtNewPwd.Text.ToString().Trim() = "" Then
            MessageBox.Show("New Password cannot be empty", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtConfirmPwd.Text.ToString().Trim() = "" Then
            MessageBox.Show("Confirm Password cannot be empty", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtNewPwd.Text.ToString().Trim() <> txtConfirmPwd.Text.ToString().Trim() Then
            MessageBox.Show("New and Confirm passwords did not match", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        sSave()
    End Sub

    Private Sub sSave()
        Dim strSQL, strData As String
        Dim oleConn As OleDbConnection
        Dim oleCmd As OleDbCommand
        Try
            strSQL = "UPDATE USER_INFO SET "
            strData = "[PASSWORD]='" & Trim(txtNewPwd.Text) & "', "


            strData = strData + "UPDATED_BY='" + strloguser + "',"
            strData = strData + "UPDATE_DATE='" + Now.Date + "'"


            strData = strData + " WHERE USER_ID= '" & Trim(strloguser) & "'"

            strSQL = strSQL + strData

            oleConn = New OleDbConnection(strDbConnect)
            If oleConn.State = ConnectionState.Closed Then oleConn.Open()
            oleCmd = New OleDbCommand(strSQL, oleConn)
            oleCmd.ExecuteNonQuery()

            MessageBox.Show("Password saved successfully!", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class