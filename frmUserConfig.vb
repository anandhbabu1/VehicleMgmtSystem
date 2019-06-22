Imports System.Data.OleDb
Public Class frmUserConfig
    Private Sub frmUserConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = strTitle & " - [User Configuration]"
            ' InitializeDataGridView()
            With Me.dgUser
                .RowsDefaultCellStyle.BackColor = Color.LightGray
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
            End With
            sLoadUserInfo()
            sClearCtrl()
        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Configures the appearance and behavior of a DataGridView control.
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.

        dgUser.BackgroundColor = Color.LightGray
        dgUser.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and 
        ' limited interactivity. 
        dgUser.AllowUserToAddRows = False
        dgUser.AllowUserToDeleteRows = False
        dgUser.AllowUserToOrderColumns = True
        dgUser.ReadOnly = True
        dgUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgUser.MultiSelect = False
        dgUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgUser.AllowUserToResizeColumns = False
        dgUser.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgUser.AllowUserToResizeRows = False
        dgUser.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        dgUser.DefaultCellStyle.SelectionBackColor = Color.White
        dgUser.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        dgUser.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows. 
        ' The value for alternating rows overrides the value for all rows. 
        dgUser.RowsDefaultCellStyle.BackColor = Color.White
        dgUser.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue

        ' Set the row and column header styles.
        dgUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgUser.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        dgUser.RowHeadersDefaultCellStyle.BackColor = Color.Black

        ' Set the Format property on the "Last Prepared" column to cause
        ' the DateTime to be formatted as "Month, Year".
        'dgUser.Columns("Last Prepared").DefaultCellStyle.Format = "y" '
    End Sub

    Private Sub sLoadUserInfo()
        Dim strSQL As String
        Dim oleConn As OleDbConnection
        Dim oleAda As OleDbDataAdapter
        Dim dtUser As New DataTable
        Try

            strSQL = "SELECT User_id as [User ID], User_name as [User Name],   User_type as [User Type]   FROM USER_INFO"
            oleConn = New OleDbConnection(strDbConnect)
            oleAda = New OleDbDataAdapter(strSQL, oleConn)
            oleAda.Fill(dtUser)
            dgUser.DataSource = dtUser

            For i As Integer = 0 To dtUser.Rows.Count - 1

                If dtUser.Rows(i).Item("User Type") = "A" Then
                    dtUser.Rows(i).Item("User Type") = "Admin User"
                End If
                If dtUser.Rows(i).Item("User Type") = "S" Then
                    dtUser.Rows(i).Item("User Type") = "Supervisor"
                End If
                If dtUser.Rows(i).Item("User Type") = "N" Then
                    dtUser.Rows(i).Item("User Type") = "Normal User"
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbAdd_CheckedChanged(sender As Object, e As EventArgs) Handles rbAdd.CheckedChanged
        If rbAdd.Checked Then
            sClearCtrl()
        End If

    End Sub

    Private Sub rbEdit_CheckedChanged(sender As Object, e As EventArgs) Handles rbEdit.CheckedChanged
        txtUserID.ReadOnly = True
        btnDelete.Visible = True
    End Sub

    Private Sub sClearCtrl()
        txtUserID.Text = ""
        txtUserName.Text = ""
        txtUserID.ReadOnly = False
        rbAdmin.Checked = False
        rbSup.Checked = False
        rbNormal.Checked = False
        btnDelete.Visible = False
        rbAdd.Checked = True
    End Sub
    Private Sub dgUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUser.CellClick
        rbEdit.Checked = True
        txtUserID.Text = dgUser.Rows(e.RowIndex).Cells(0).Value
        txtUserName.Text = dgUser.Rows(e.RowIndex).Cells(1).Value
        If dgUser.Rows(e.RowIndex).Cells(2).Value = "A" Then
            rbAdmin.Checked = True
        End If
        If dgUser.Rows(e.RowIndex).Cells(2).Value = "S" Then
            rbSup.Checked = True
        End If
        If dgUser.Rows(e.RowIndex).Cells(2).Value = "N" Then
            rbNormal.Checked = True
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rbAdd.Checked Then
            sAdduser()
        End If
        If rbEdit.Checked Then
            sEditUser()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strSQL, strData As String
        Dim oleConn As OleDbConnection
        Dim oleCmd As OleDbCommand
        Try
            If MessageBox.Show("You are deleting a user, are you sure?", strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            strSQL = "DELETE FROM USER_INFO WHERE USER_ID = "
            strData = "'" & Trim(txtUserID.Text) & "'"

            strSQL = strSQL + strData


            oleConn = New OleDbConnection(strDbConnect)
            If oleConn.State = ConnectionState.Closed Then oleConn.Open()
            oleCmd = New OleDbCommand(strSQL, oleConn)
            oleCmd.ExecuteNonQuery()
            MessageBox.Show("User Info delete succesfully!", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            sClearCtrl()
            sLoadUserInfo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub sAdduser()
        Dim strSQL, strData As String
        Dim oleConn As OleDbConnection
        Dim oleCmd As OleDbCommand
        Try
            strSQL = "INSERT INTO USER_INFO (User_Id, User_Name, User_Type, User_status, Created_by, Created_date, Updated_By, Update_date) VALUES ("
            strData = "'" & Trim(txtUserID.Text) & "','"
            strData = strData & Trim(txtUserName.Text) & "',"

            If rbAdmin.Checked Then
                strData = strData & "'A','"
            End If

            If rbSup.Checked Then
                strData = strData & "'S','"
            End If

            If rbNormal.Checked Then
                strData = strData & "'N','"
            End If

            strData = strData + "A"
            strData = strData + "','" + strloguser
            strData = strData + "','" + Now.Date
            strData = strData + "','" + strloguser
            strData = strData + "','" + Now.Date
            strData = strData + "')"

            strSQL = strSQL + strData

            oleConn = New OleDbConnection(strDbConnect)
            If oleConn.State = ConnectionState.Closed Then oleConn.Open()
            oleCmd = New OleDbCommand(strSQL, oleConn)
            oleCmd.ExecuteNonQuery()

            MessageBox.Show("User Info saved succesfully!", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            sClearCtrl()
            sLoadUserInfo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub sEditUser()
        Dim strSQL, strData As String
        Dim oleConn As OleDbConnection
        Dim oleCmd As OleDbCommand
        Try
            strSQL = "UPDATE USER_INFO SET "
            strData = "USER_NAME='" & Trim(txtUserName.Text) & "',"
            strData = strData + "USER_TYPE="

            If rbAdmin.Checked Then
                strData = strData & "'A',"
            End If

            If rbSup.Checked Then
                strData = strData & "'S',"
            End If

            If rbNormal.Checked Then
                strData = strData & "'N',"
            End If



            strData = strData + "UPDATED_BY='" + strloguser + "',"
            strData = strData + "UPDATE_DATE='" + Now.Date + "'"


            strData = strData + " WHERE USER_ID= '" & Trim(txtUserID.Text) & "'"

            strSQL = strSQL + strData

            oleConn = New OleDbConnection(strDbConnect)
            If oleConn.State = ConnectionState.Closed Then oleConn.Open()
            oleCmd = New OleDbCommand(strSQL, oleConn)
            oleCmd.ExecuteNonQuery()

            MessageBox.Show("User Info saved succesfully!", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            sClearCtrl()
            sLoadUserInfo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class