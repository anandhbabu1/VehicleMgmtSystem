Public Class frmCompanySetup
    Private Sub frmCompanySetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strTitle + " - [Company Setup]"
        Dim dtTable As New DataTable
        dtTable.Columns.Add("Company Name")
        dtTable.Columns.Add("Address")
        dtTable.Columns.Add("Phone")
        dtTable.Columns.Add("Email")
        Dim dr As DataRow

        dr = dtTable.NewRow
        dr("Company Name") = "ABC Company Inc"
        dr("Address") = "ABC Company Address"
        dr("Phone") = "456-123-7890"
        dr("Email") = "abccompany@gmail.com"

        dtTable.Rows.Add(dr)


        dr = dtTable.NewRow
        dr("Company Name") = "XYZ Company Inc"
        dr("Address") = "XYZ Company Address"
        dr("Phone") = "456-123-7890"
        dr("Email") = "XYZcompany@gmail.com"

        dtTable.Rows.Add(dr)

        dgCompany.DataSource = dtTable

    End Sub
End Class