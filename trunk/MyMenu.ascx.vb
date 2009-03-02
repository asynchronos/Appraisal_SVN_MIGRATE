Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO



Partial Class MyMenu
    Inherits System.Web.UI.UserControl

    Private _cssFile As String
    Private _vert As String
    Private _diffWidth As String
    Private _defWidthValue As Integer
    Private _defHeightValue As Integer
    Private _centerMenu As String
    Private _follScroll As String
    Private _hrImg As String
    Private strConnection As String = "server=172.19.54.2;Database=Appraisal;uid=sa;pwd=sa0123"

#Region " Properties "

    'By defining properties we are able to get variables that change our menu look
    'from menu's tag in aspx page. Menu tag's attribute with same name to this property 
    'gets given value.
    Public Property CSSFile() As String
        Get
            Return _cssFile
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                _cssFile = "default.css"
            End If
            _cssFile = Value
        End Set
    End Property

    Public Property Vertical() As String
        Get
            Return _vert
        End Get
        Set(ByVal Value As String)
            If Value.ToLower <> "true" And Value.ToLower <> "false" Then
                _vert = "false"
            Else
                _vert = Value.ToLower
            End If
        End Set
    End Property

    Public Property DiffWidth() As String
        Get
            Return _diffWidth
        End Get
        Set(ByVal Value As String)
            If Value.ToLower <> "true" And Value.ToLower <> "false" Then
                _diffWidth = "true"
            Else
                _diffWidth = Value.ToLower
            End If
        End Set
    End Property

    Public Property DefaultWidth() As Integer
        Get
            Return _defWidthValue
        End Get
        Set(ByVal Value As Integer)
            If IsNumeric(Value) Then
                _defWidthValue = CInt(Value)
            Else
                _defWidthValue = 95
            End If
        End Set
    End Property

    Public Property DefaultHeight() As Integer
        Get
            Return _defHeightValue
        End Get
        Set(ByVal Value As Integer)
            If IsNumeric(Value) Then
                _defHeightValue = CInt(Value)
            Else
                _defHeightValue = 25
            End If
        End Set
    End Property

    Public Property CenterMenu() As String
        Get
            Return _centerMenu
        End Get
        Set(ByVal Value As String)
            If Value.ToLower <> "true" And Value.ToLower <> "false" Then
                _centerMenu = "false"
            Else
                _centerMenu = Value.ToLower
            End If
        End Set
    End Property

    Public Property FollowScroll() As String
        Get
            Return _follScroll
        End Get
        Set(ByVal Value As String)
            If Value.ToLower <> "true" And Value.ToLower <> "false" Then
                _follScroll = "true"
            Else
                _follScroll = Value.ToLower
            End If
        End Set
    End Property

    Public Property HRImage() As String
        Get
            Return _hrImg
        End Get
        Set(ByVal Value As String)
            _hrImg = Value
        End Set
    End Property

#End Region

    Public Sub New()
        Me._cssFile = "lookxp.css"
        Me._vert = "true"
        Me._diffWidth = "true"
        Me._defWidthValue = 95
        Me._defHeightValue = 25
        Me._centerMenu = "false"
        Me._follScroll = "true"
        Me._hrImg = "lookxphr.gif"
    End Sub

#Region " Web Form Designer Generated Code "


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "DataSetHelper Class"
    'Puclic Class DataSetHelper is as in article HOW TO: Implement a DataSet SELECT DISTINCT Helper Class in Visual C# .NET
    'by Microsoft, with Article ID: 326176
    'http://support.microsoft.com/default.aspx?scid=kb;en-us;326176
    'Author made a Shared version of functions (as used in this code) and that code can be reached at:
    'http://codebetter.com/blogs/sahil.malik/archive/2004/12/26/39040.aspx
    'Converted to VisualBasic.Net from C# by VBNET Translator at:
    'http://authors.aspalliance.com/aldotnet/examples/translate.aspx
    '
    'We are using SelectDistinct method defined here in BuildMenu() function below, that builds our menu,
    ' to get distinct main menu titles when our database stored procedure reads every sub-menu item.
    Public Class DataSetHelper

        Private Shared Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean

            ' Compares two values to see if they are equal. Also compares DBNULL.Value.
            ' Note: If your DataTable contains object fields, then you must extend this
            ' function to handle them in a meaningful way if you intend to group on them.
            If A Is DBNull.Value And B Is DBNull.Value Then '  both are DBNull.Value
                Return True
            End If
            If A Is DBNull.Value Or B Is DBNull.Value Then '  only one is DBNull.Value
                Return False
            End If
            Return A.Equals(B) ' value type standard comparison
        End Function 'ColumnEqual

        Public Shared Function SelectDistinct(ByVal TableName As String, ByVal SourceTable As DataTable, ByVal FieldName As String) As DataTable
            Dim dt As New DataTable(TableName)
            dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)

            Dim LastValue As Object = DBNull.Value
            Dim dr As DataRow
            For Each dr In SourceTable.Select("", FieldName)
                If LastValue Is Nothing Or Not ColumnEqual(LastValue, dr(FieldName)) Then
                    LastValue = dr(FieldName)
                    dt.Rows.Add(New Object() {LastValue})
                End If
            Next dr
            Return dt
        End Function 'SelectDistinct

    End Class 'DataSetHelper
#End Region

    Dim myConnection As SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("permission") = 0
        'Session("division") = 1



        Try
            myConnection = New SqlConnection(strConnection)
            myConnection.Open()
        Catch ex As Exception
            menuLiteral.Text = ex.Message
        End Try
        If Session("menuString") Is Nothing Then
            menuLiteral.Text = BuildMenu()
        Else
            menuLiteral.Text = Session("menuString").ToString()
        End If
    End Sub

    Private Function BuildMenu() As String

        Dim ulOpened As Boolean = False
        Dim myAdapter As SqlDataAdapter
        Dim myTable As DataTable

        '*****Production Stroprocedure ON Create Menu********
        'Dim SQLCmdAllMenu As New SqlCommand("sp_CreateMenu_Svr", myConnection)
        '*****************************************************************

        '***** Testing Stroprocedure ON Create Menu **********************
        Dim SQLCmdAllMenu As New SqlCommand("sp_CreateMenu", myConnection)
        '*****************************************************************

        SQLCmdAllMenu.CommandType = CommandType.StoredProcedure
        'SQLCmdAllMenu.Parameters.Add("permission", SqlDbType.TinyInt).Value = Session("permission")
        'SQLCmdAllMenu.Parameters.Add("division", SqlDbType.TinyInt).Value = Session("division")
        SQLCmdAllMenu.Parameters.Add("GroupId", SqlDbType.TinyInt).Value = Session("sGroup_Id")
        myAdapter = New SqlDataAdapter(SQLCmdAllMenu)


        Dim menuId As Integer
        'nbMenus is the number of top-level menus
        Dim nbMenus As Integer = 0
        'menu0 is a dummy variable to check menu titles with new ones when a new one added
        Dim menu0 As String = ""

        Dim imageOption As String
        Dim urlOption As String
        'If exist some arguments a new window will be opened. So onClick variable shall be filled and added to anchor tag 
        Dim onClick As String
        'mySt is the string that contains all HTML code of menu
        Dim mySt As New StringBuilder

        myTable = New DataTable

        myAdapter.Fill(myTable)

        myAdapter.Dispose()

        imageOption = ""


        Dim myRow As DataRow


        'myMainMenuURL will keep URL that redirects when a main menu title clicked
        Dim myMainMenuURL As String

        ' A dummy data table to hold all distinct main menu titles available in
        ' myTable data table variable. This is needed because in the stored procedure that
        ' returns all menu information every meu item holds it's parent menu id.
        ' Meaning in that table main menu items exist more than once.
        Dim mainMenuTitles As DataTable
        mainMenuTitles = DataSetHelper.SelectDistinct("MainMenuTitles", myTable, "mainMenuTitle")

        nbMenus = mainMenuTitles.Rows.Count

        'varCenterAll is the string that holds javascript line for variable defining if menu centered or not.
        '(If vertical vertically centered, if horizontal horizontally centered)
        Dim varCenterAll As String = "var centrer_menu = " & CenterMenu & ";"

        Dim varMainWidth As String = ""
        Dim varMainHeight As String = ""

        'Dummy string variable mainTitleDum will be used to check in For loop
        'to see if current main menu title is the same as one cheked in previous
        'itteration of for loop. If it's not then it means it's a distinct main menu title
        'and previous paragraph tag <P> needs to be closed and new one needs to be opened.
        Dim mainTitleDum As String = ""

        'ATTENTION: even though it's called DiffWidth property as short for Different Width
        'this variable actually says if we are going to use different values for main
        'menu titles' widths if menu in horizontal mode, or, different height values if menu
        'in vertical mode.
        If DiffWidth = "true" And Vertical <> "true" Then
            'For horizontal menu with different width option of main menu titles choosen
            'instead of using one width value we have to use an array of values.
            varMainWidth = "var largeur_menu = new Array("

            For Each myRow In myTable.Rows
                If myRow("mainMenuTitle") <> mainTitleDum Then
                    'You can use a different multiplier instead of 10. This function gives
                    '10 pixels of width for each letter in ain menu title which is enough
                    'for given style sheets. If you use larger fonts in your style sheets
                    'you better increase the multiplier. It's a try and see thing.
                    varMainWidth &= (myRow("mainMenuTitle").ToString.Length * 10).ToString & ","
                    mainTitleDum = myRow("mainMenuTitle")
                End If
            Next
            'last coma needs to be deleted at the end of string that defines javascript array holding
            'width variables.
            varMainWidth = varMainWidth.Remove(varMainWidth.Length - 1, 1)
            varMainWidth &= ");"

        ElseIf DiffWidth = "true" And Vertical = "true" Then
            'For vertical menu with different height option of main menu titles choosen
            'instead of using one height value we have to use an array of values.
            varMainWidth = "var largeur_menu = " & DefaultWidth.ToString & ";"

            'Dim dumyStr As String

            Dim largeur As Integer 'largeur means width in French

            'I wanted to keep width of main menu titles at times of 10
            'because in given CSS files (example css files given with this project)
            'each letter is as big to fit in 10 pixels area.
            'That will be our starting point for the calculations we are about to make.
            'If you consider using larger font sizes in your CSS files, you might need to consider
            'greater values than 10.
            'DefaultWidth property is supposed to hold a value enough to keep an average
            'main menu title plus some free space on the sides.
            largeur = Math.Floor(DefaultWidth / 10) * 10

            varMainHeight = "var hauteur_menu = new Array("
            Dim hautDummy As Integer
            Dim hautonethird As Integer = Math.Floor(DefaultHeight / 3)

            For Each myRow In myTable.Rows
                If myRow("mainMenuTitle") <> mainTitleDum Then
                    'Lets say if main menu title is larger than number of letters * 10 plus
                    '50 pixels, it means that it can't fit in an average title box, so
                    'we have to make a second line. Some words in the title will hopefully
                    'written in second line and it will look neat.
                    If largeur + 50 < myRow("mainMenuTitle").ToString.Length * 10 Then
                        'Because of extra space, multiplying default height would give too
                        'big menu title box. I came up with this formula.
                        hautDummy = DefaultHeight * 2 - Math.Floor(hautonethird * 2)
                        varMainHeight &= hautDummy.ToString & ","
                    Else
                        'If numer of letter * 10 + 50 pixels can keep the title
                        'then why to bother with calculating a new value?
                        'Use default height.
                        varMainHeight &= DefaultHeight.ToString & ","
                    End If
                    mainTitleDum = myRow("mainMenuTitle")
                End If
            Next
            'We have to delete last coma and write ); instead
            varMainHeight = varMainHeight.Remove(varMainHeight.Length - 1, 1)
            varMainHeight &= ");"
        Else
            'If DiffWidth property set to false, then we just use default width and
            'height values.
            varMainWidth = "var largeur_menu = " & DefaultWidth.ToString & ";"
            varMainHeight = "var hauteur_menu = " & DefaultHeight.ToString & ";"
        End If

        'Now its time to write all those variable we defined in javascript before
        'we call our menu.
        mySt.Append("<script language=""javascript"" type=""text/javascript"">" & ControlChars.Lf)
        mySt.Append(ControlChars.Tab & varMainWidth & ControlChars.Lf)
        mySt.Append(ControlChars.Tab & varMainHeight & ControlChars.Lf)
        mySt.Append(ControlChars.Tab & varCenterAll & ControlChars.Lf)
        mySt.Append(ControlChars.Tab & "</script>")

        'rest of javascript functions and variables are in menu.js file. We call that.
        mySt.Append(String.Format("<script language=""javascript"" type=""text/javascript"" src=""menu/menu.js""></script>" & ControlChars.Lf))

        'Here we use css file name we received from menu's property named CSSFile
        'We can use an If statement to check if css file name is defined.
        'If not a default one can be implemented.
        'Up to you to code.
        mySt.Append(String.Format("<link rel=""stylesheet"" type=""text/css"" href=""menu/{0}"">" & ControlChars.Lf, CSSFile))

        'We start the creation of menu here
        mySt.Append("<div id=""conteneurmenu"">" & ControlChars.Lf)
        mySt.Append("<script language=""Javascript"" type=""text/javascript""" & ">" & ControlChars.Lf)
        ' Number of main menu items is needed for javascript code to work properly.
        'Some other variables defined in menu control's properties are defined here
        'in javascript variables.
        mySt.Append("var nbmenu=" & nbMenus & ";" & ControlChars.Lf)
        mySt.Append("var suivre_le_scroll=" & FollowScroll & ";" & ControlChars.Lf)
        mySt.Append("var vertical=" & Vertical & ";" & ControlChars.Lf)
        mySt.Append("preChargement();" & ControlChars.Lf)
        mySt.Append("</script>" & ControlChars.Lf)

        menuId = 0
        'menuId=0 is to check first execution of for loop which will construct the menu.
        'If menuId is not 0 that means we read some data in a previous execution of the loop
        'therefore we must write closing HTML tags.

        ' Construction of menu mainly done in this for loop.
        For Each myRow In myTable.Rows
            If myRow("mainMenuTitle").ToString() <> menu0 Then

                'If this is not first read, that means we must close tags of previous execution.
                If menuId <> 0 And ulOpened = True Then
                    mySt.Append(ControlChars.Tab & ControlChars.Tab & "</ul>" & ControlChars.Lf)
                    ulOpened = False
                End If
                'Here we get URLs of main menu titles
                Dim mySqlMainMenuCmd As New SqlCommand("sp_mainMenuURL", myConnection)
                mySqlMainMenuCmd.CommandType = CommandType.StoredProcedure
                mySqlMainMenuCmd.Parameters.Add("mainMenuTitleArg", SqlDbType.NVarChar, 60).Value = myRow("mainMenuTitle").ToString()
                'ExecuteScalar reads only one item from data table (first row, first column), which we know that we only have an URL for given
                'main menu title
                If mySqlMainMenuCmd.ExecuteScalar Is DBNull.Value Then
                    myMainMenuURL = ""
                Else
                    myMainMenuURL = mySqlMainMenuCmd.ExecuteScalar
                End If

                menuId += 1


                If myRow("subMenuTitle") Is DBNull.Value Then

                    'Main menu (top-menu) items are held in paragraph HTML tags <P>
                    mySt.Append(String.Format(ControlChars.Tab & "<p id=""menu{0}"" class=""menu"">" & ControlChars.Lf, menuId))
                    If Not myMainMenuURL = "" Then
                        mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & "<a href=""{1}"" >{0}<span> :</span></a>" & ControlChars.Lf, myRow("mainMenuTitle").ToString(), myMainMenuURL))
                    Else
                        mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & "<a href=""javascript:void(0);"" >{0}<span> :</span></a>" & ControlChars.Lf, myRow("mainMenuTitle").ToString()))
                    End If

                    mySt.Append(ControlChars.Tab & "</p>" & ControlChars.Lf)

                Else

                    'Main menu (top-menu) items are held in paragraph HTML tags <P>
                    mySt.Append(String.Format(ControlChars.Tab & "<p id=""menu{0}"" class=""menu"" onmouseover=""MontrerMenu('ssmenu{0}');"" onmouseout=""CacherDelai();"">" & ControlChars.Lf, menuId))
                    If Not myMainMenuURL = "" Then
                        mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & "<a href=""{2}"" onfocus=""MontrerMenu('ssmenu{0}');"">{1}<span> :</span></a>" & ControlChars.Lf, menuId, myRow("mainMenuTitle").ToString(), myMainMenuURL))
                    Else
                        mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & "<a href=""javascript:void(0);"" onfocus=""MontrerMenu('ssmenu{0}');"">{1}<span> :</span></a>" & ControlChars.Lf, menuId, myRow("mainMenuTitle").ToString(), myMainMenuURL))
                    End If

                    mySt.Append(ControlChars.Tab & "</p>")

                    'Sub-menu items are grouped in unnumbered list tags below their top-menu titles
                    mySt.Append(String.Format(ControlChars.Lf & ControlChars.Tab & ControlChars.Tab & "<ul id=""ssmenu{0}"" class=""ssmenu"" onmouseover=""AnnulerCacher();"" onmouseout=""CacherDelai();"" onfocus=""AnnulerCacher();"" onblur=""CacherDelai();"">" & ControlChars.Lf, menuId))
                    ulOpened = True
                End If

                menu0 = myRow("mainMenuTitle").ToString()
            End If

            If myRow("subMenuTitle") Is DBNull.Value Then
                'Do Nothing
            Else
                If myRow("iconImage").ToString().Length <> 0 Then
                    imageOption = myRow("iconImage").ToString()
                Else
                    imageOption = "lookxpvide.gif"
                End If

                'To avoid "Page Cannot Be Shown" error when there is no URL entered in database,
                'instead of writing empty string we use Javascript's void function.
                'Otherwise we write appropriate URL.
                If myRow("URL").ToString().Length <> 0 Then
                    urlOption = myRow("URL").ToString()
                Else
                    urlOption = "javascript:void(0);"
                End If


                'If we have new window arguments in database, we hold them in urlOption variable.
                'this variable like imageOption which holds icon image filename,
                'will be added to string that forms each submenu item, just in the lines to follow.
                If myRow("newWinArgs").ToString().Length <> 0 Then
                    onClick = " onClick=""Javascript:window.open('" & urlOption & "','window','" & myRow("newWinArgs").ToString() & "'); return false;"" "
                Else
                    onClick = ""
                End If

                'If icon image of given sub menu item is same with menu property HRImage,
                'It means we are supposed to see just a horizontal ruler image that seperates
                'two submenu items and not a real menu title text or menu icon image.
                If myRow("iconImage").ToString() = HRImage Then
                    mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & ControlChars.Tab & "<img src=""menu/{0}"" class =""hr"" align=""absmiddle"" alt=""""/>" & ControlChars.Lf, imageOption))
                Else
                    'Each submenu item is a HTML list item, we add here all their variables and form full
                    'list item html string.
                    mySt.Append(ControlChars.Tab & ControlChars.Tab & ControlChars.Tab & "<li>" & ControlChars.Lf)
                    mySt.Append(String.Format(ControlChars.Tab & ControlChars.Tab & ControlChars.Tab & ControlChars.Tab & "<a href=""{0}"" {1}><img src=""menu/{2}"" align=""absmiddle"" alt=""""/> {3} <span> ;</span></a>" & ControlChars.Lf, urlOption, onClick, imageOption, myRow("subMenuTitle").ToString()))
                    mySt.Append(ControlChars.Tab & ControlChars.Tab & ControlChars.Tab & "</li>" & ControlChars.Lf)
                End If

            End If

        Next myRow

        If ulOpened = True Then
            'We close our menu
            mySt.Append(ControlChars.Tab & ControlChars.Tab & "</ul>" & ControlChars.Lf)
            ulOpened = False
        End If

        mySt.Append("</div>" & ControlChars.Lf)
        mySt.Append("<script language=""Javascript"" type=""text/javascript"">Chargement();</script>" & ControlChars.Lf)

        Session("menuString") = mySt.ToString()
        Return mySt.ToString()
    End Function 'BuildMenu 

End Class
