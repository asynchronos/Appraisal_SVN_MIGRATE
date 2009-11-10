Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web

<ServiceContract(Namespace:="")> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class Service

    ' Add <WebGet()> attribute to use HTTP GET 
    <OperationContract()> _
    Public Sub DoWork()
        ' Add your operation implementation here
    End Sub

    ' Add more operations here and mark them with <OperationContract()>
    <OperationContract()> _
    Function Validate(ByVal bypass As String) As Boolean
        Return True
    End Function


    <OperationContract()> _
Function ValidateValidateSave(ByVal land As Double, ByVal building As Double) As Boolean
        Threading.Thread.Sleep(5000)
        Dim IsValid As Boolean = False

        Try
            'txtTotal.Text = land + building
            IsValid = True
        Catch ex As Exception

        End Try
        Return IsValid
    End Function
End Class
