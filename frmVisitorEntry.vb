Public Class frmVisitorEntry
    Private Sub frmVisitorEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strTitle + " - [Visitor Details]"

        Dim dtTable As New DataTable
        dtTable.Columns.Add("Company Name")
        dtTable.Columns.Add("Address")

        Dim dr As DataRow

        dr = dtTable.NewRow
        dr("Company Name") = "ABC Company Inc"


        dtTable.Rows.Add(dr)


        dr = dtTable.NewRow
        dr("Company Name") = "XYZ Company Inc"


        dtTable.Rows.Add(dr)

        cbCompany.Items.Add("ABC Company Inc")
        cbCompany.Items.Add("XYZ Company Inc")

        picPhoto.BackgroundImage = My.Resources.user_img


        txtFName.Text = "ABC Visitor First"


        txtLName.Text = "ABC Visitor Last"
        cbCompany.SelectedIndex = 0
        rbMale.Checked = True
        txtPassport.Text = "P1234567"
        dtRegister.Value = Now.Date
        dtRegister.Format = DateTimePickerFormat.Custom
        dtRegister.CustomFormat = "dd/MM/yyyy"
        txtLastvisitdate.Text = Format(Now.Date, "dd/MM/yyyy")


    End Sub
End Class