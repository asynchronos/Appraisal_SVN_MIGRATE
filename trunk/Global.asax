<%@ Application Language="VB" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="log4net" %>
<script runat="server">
    Private Shared ReadOnly log As ILog = _
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private Shared ReadOnly isDebugEnabled As Boolean = log.IsDebugEnabled
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        log4net.Config.XmlConfigurator.Configure()
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim err As Exception = Server.GetLastError()

        ''Creation of event log if it does not exist
        'Dim eventLogName As String = "SmeRisk"
        'If Not EventLog.SourceExists(eventLogName) Then
        'EventLog.CreateEventSource(eventLogName, eventLogName)
        'End If

        ''Inserting into event log
        'Dim eLog As EventLog = New EventLog()
        'eLog.Source = eventLogName
        'eLog.WriteEntry(err.ToString(), EventLogEntryType.Error)

        'Insert log by log4net
        
        log.Error(err.Message, err)
        
        'send mail
        'System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
        'String ErrorMessage = "The error description is as follows : " + ErrorDescription;
        'mail.To = "mail@domail.com";
        'mail.Subject = "Error in the " + eventLogName + "site";
        'mail.Priority = System.Web.Mail.MailPriority.High;
        'mail.BodyFormat = System.Web.Mail.MailFormat.Text;
        'mail.Body = ErrorMessage;
        'System.Web.Mail.SmtpMail.Send(mail);
        
        'redirect to error page
        'If err.GetType().Equals(GetType(System.Security.SecurityException)) Then
        '    Response.Redirect("~/MyAspx/Error/unauthorized.aspx?page=" & Server.UrlEncode(Request.RawUrl))
        'Else
        '    Response.Redirect(("~/MyAspx/Error/defaultError.aspx?page=" & Server.UrlEncode(Request.RawUrl) & "&msg=") + err.InnerException.Message)
        'End If
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>