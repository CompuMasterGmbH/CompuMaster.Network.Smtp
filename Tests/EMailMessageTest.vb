﻿Imports NUnit.Framework
Imports CompuMaster.Net.Smtp

<TestFixture> Public Class EMailMessageTest

    <Test> Public Sub Initialization()
        Dim MyMessage1 As New EMailMessage()
        Dim MyMessage3 As New EMailMessage(New EMailAddress("Jon Doe", "jon.doe@domain.invalid"), "Test without embedded image attachment", "plain body", "<h1>html body</h1>", New EMailAddress("Sender Doe", "sender.doe@domain.invalid"), New EMailAddress("Reply Doe", "reply.doe@domain.invalid"))
        Dim MyAttachments As New List(Of EMailAttachment)(New EMailAttachment() {New EMailAttachment("logo_64x64.png", "logo")})
        Dim AdditionalHeaders As New Specialized.NameValueCollection
        AdditionalHeaders("X-CustomTestHeader") = "Test"
        Dim MyMessage4 As New EMailMessage(New EMailAddress("Jon Doe", "jon.doe@domain.invalid"), "Test with embedded image attachment", "plain body", "<h1>html body</h1><img src=""cid:" & MyAttachments(0).PlaceholderInMhtmlToBeReplacedByContentID & """>", New EMailAddress("Sender Doe", "sender.doe@domain.invalid"), New EMailAddress("Reply Doe", "reply.doe@domain.invalid"), System.Text.Encoding.UTF32, MyAttachments, EMails.Priority.High, EMails.Sensitivity.CompanyConfidential, True, True, AdditionalHeaders)
        Dim MyMessage5 As New EMailMessage(New List(Of EMailAddress)(New EMailAddress() {New EMailAddress("Jon Doe", "jon.doe@domain.invalid")}), CType(Nothing, List(Of EMailAddress)), CType(Nothing, List(Of EMailAddress)), "Test with embedded image attachment", "plain body", "<h1>html body</h1><img src=""cid:" & MyAttachments(0).PlaceholderInMhtmlToBeReplacedByContentID & """>", New EMailAddress("Sender Doe", "sender.doe@domain.invalid"), New EMailAddress("Reply Doe", "reply.doe@domain.invalid"), System.Text.Encoding.UTF32, MyAttachments, EMails.Priority.High, EMails.Sensitivity.CompanyConfidential, True, True, AdditionalHeaders)
        Dim MyMessage5Serialized As String = MyMessage5.ExportToXml
        Dim MyMessage2 As New EMailMessage(MyMessage5Serialized)
        Assert.AreEqual(MyMessage5, MyMessage2)
    End Sub
End Class
