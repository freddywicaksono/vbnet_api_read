Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.IO
Public Class Employee
    Public RecordFound As Boolean = False
    Public InsertData As Boolean = False
    Public UpdateData As Boolean = False
    Public DeleteData As Boolean = False
    Private _id As Integer
    Private _name As String
    Private _email As String
    Private _designation As String
    Private _created As String
    Private _token As String
    Private _apilink As String
    Private _method As String
    Private _response As String


    Public Property ID()
        Get
            Return _id
        End Get
        Set(ByVal value)
            _id = value
        End Set
    End Property

    Public Property Name()
        Get
            Return _name
        End Get
        Set(ByVal value)
            _name = value
        End Set
    End Property
    Public Property Email()
        Get
            Return _email
        End Get
        Set(ByVal value)
            _email = value
        End Set
    End Property
    Public Property Designation()
        Get
            Return _designation
        End Get
        Set(ByVal value)
            _designation = value
        End Set
    End Property
    Public Property Created()
        Get
            Return _created
        End Get
        Set(ByVal value)
            _created = value
        End Set
    End Property
    Public Property Token()
        Get
            Return _token
        End Get
        Set(ByVal value)
            _token = value
        End Set
    End Property
    Public Property APILink()
        Get
            Return _apilink
        End Get
        Set(ByVal value)
            _apilink = value
        End Set
    End Property
    Public Property Method()
        Get
            Return _method
        End Get
        Set(ByVal value)
            _method = value
        End Set
    End Property
    Public Property Response()
        Get
            Return _response
        End Get
        Set(ByVal value)
            _response = value
        End Set
    End Property

    Public Sub Simpan()
        Dim postdata As String
        Dim wstatus As String

        postdata = "token=" & _token & "&id=" & _id & "&name=" & _name & "&email=" & _email & "&designation=" & _designation
        _response = WRequest(_apilink, _method, postdata)
        Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(_response)
        wstatus = jsonResulttodict.Item("status")
        If (wstatus = "success") Then
            InsertData = True
        Else
            InsertData = False
        End If
    End Sub

    Public Sub UpdateRecord(ByVal sid As String)
        Dim postdata As String
        Dim wstatus As String

        _created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        postdata = "token=" & _token & "&id=" & _id & "&name=" & _name & "&email=" & _email & "&designation=" & _designation & "&created=" & _created
        _response = WRequest(_apilink, _method, postdata)
        Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(_response)
        wstatus = jsonResulttodict.Item("status")
        If (wstatus = "success") Then
            UpdateData = True
        Else
            UpdateData = False
        End If
    End Sub

    Public Sub CariEmployee(ByVal sid As String)
        Dim postdata As String
        Dim wstatus As String
        postdata = "token=" & _token & "&id=" & sid

        _response = WRequest(_apilink, _method, postdata)
        Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(_response)
        wstatus = jsonResulttodict.Item("status")
        If (wstatus = "success") Then
            _name = jsonResulttodict.Item("name")
            _email = jsonResulttodict.Item("email")
            _designation = jsonResulttodict.Item("designation")
            RecordFound = True
        Else
            RecordFound = False
        End If

    End Sub

    Public Sub DeleteRecord(ByVal sid As String)
        Dim postdata As String
        Dim wstatus As String
        postdata = "token=" & _token & "&id=" & sid

        _response = WRequest(_apilink, _method, postdata)
        Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(_response)
        wstatus = jsonResulttodict.Item("status")
        If (wstatus = "success") Then
            DeleteData = True

        Else
            DeleteData = False

        End If
    End Sub

    Public Sub getAllData(ByVal DS As DataSet, ByVal DG As DataGridView, ByVal TagRoot As String)
        Dim postdata As String
        postdata = "token=" & _token
        _response = WRequest(_apilink, _method, postdata)
        Dim srXmlData As New System.IO.StringReader(_response)
        DS.Clear()
        DS.ReadXml(srXmlData)

        DG.DataSource = DS
        DG.DataMember = TagRoot
        DG.Refresh()
    End Sub
End Class
