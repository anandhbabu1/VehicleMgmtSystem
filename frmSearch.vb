Public Class frmSearch
    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strTitle + " - [Search]"

        dgSearch.Rows.Add()
        dgSearch.Rows(0).Cells(0).Value = "ABC Visitor First"
        dgSearch.Rows(0).Cells(1).Value = "ABC Visitor Last"
        dgSearch.Rows(0).Cells(2).Value = "ABC Company Inc."
        dgSearch.Rows(0).Cells(3).Value = "P1234567"
        dgSearch.Rows(0).Cells(4).Value = Format(Now.Date, "dd/MM/yyyy")
        dgSearch.Rows(0).Cells(5).Value = Format(Now.Date, "dd/MM/yyyy")

        dtLastvisit.Value = Now.Date
        dtLastvisit.Format = DateTimePickerFormat.Custom
        dtLastvisit.CustomFormat = "dd/MM/yyyy"

        dtRegister.Value = Now.Date
        dtRegister.Format = DateTimePickerFormat.Custom
        dtRegister.CustomFormat = "dd/MM/yyyy"
    End Sub
End Class