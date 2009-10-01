Type.registerNamespace('Sys.Net');

Sys.Net.XMLHttpSyncExecutor = function()
{
    Sys.Net.XMLHttpSyncExecutor.initializeBase(this);

    this._started = false;
    this._responseAvailable = false;

    this._onReceiveHandler = null;

    this._responseData = null;
    this._statusCode = null;
    this._statusText = null;
    this._headers = null;
}

Sys.Net.XMLHttpSyncExecutor.prototype =
{
    get_aborted : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        return false;
    },

    get_responseAvailable : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        return this._responseAvailable;
    },

    get_responseData : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (!this._responseAvailable)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallBeforeResponse, 'get_responseData'));
        }

        return this._responseData;
    },

    get_started : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        return this._started;
    },

    get_statusCode : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (!this._responseAvailable)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallBeforeResponse, 'get_statusCode'));
        }

        return this._statusCode;
    },

    get_statusText : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (!this._responseAvailable)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallBeforeResponse, 'get_statusText'));
        }

        return this._statusText;
    },

    get_xml : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (!this._responseAvailable)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallBeforeResponse, 'get_xml'));
        }

        var xml = this._responseData;

        if ((!xml) || (!xml.documentElement))
        {
            xml = new XMLDOM(this._responseData);

            if ((!xml) || (!xml.documentElement))
            {
                return null;
            }
        }
        else if (navigator.userAgent.indexOf('MSIE') !== -1)
        {
            xml.setProperty('SelectionLanguage', 'XPath');
        }

        if ((xml.documentElement.namespaceURI === "http://www.mozilla.org/newlayout/xml/parsererror.xml") &&
            (xml.documentElement.tagName === "parsererror"))
        {
            return null;
        }

        if (xml.documentElement.firstChild && xml.documentElement.firstChild.tagName === "parsererror")
        {
            return null;
        }

        return xml;
    },

    executeRequest : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (this._started)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallOnceStarted, 'executeRequest'));
        }

        var webRequest = this.get_webRequest();

        if (webRequest === null)
        {
            throw Error.invalidOperation(Sys.Res.nullWebRequest);
        }

        var body = webRequest.get_body();
        var headers = webRequest.get_headers();
        var verb = webRequest.get_httpVerb();

        var xmlHttpRequest = new XMLHttpRequest();
        this._onReceiveHandler = Function.createCallback(this._onReadyStateChange, {sender:this, xmlHttp:xmlHttpRequest});
        this._started = true;
        xmlHttpRequest.onreadystatechange = this._onReceiveHandler;
        xmlHttpRequest.open(verb, webRequest.getResolvedUrl(), false); // False to call Synchronously

        if (headers)
        {
            for (var header in headers)
            {
                var val = headers[header];

                if (typeof(val) !== "function")
                {
                    xmlHttpRequest.setRequestHeader(header, val);
                }
            }
        }

        if (verb.toLowerCase() === "post")
        {
            if ((headers === null) || !headers['Content-Type'])
            {
                xmlHttpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            }

            if (!body)
            {
                body = '';
            }
        }

        xmlHttpRequest.send(body);
    },

    getAllResponseHeaders : function()
    {
        if (arguments.length !== 0) throw Error.parameterCount();

        if (!this._responseAvailable)
        {
            throw Error.invalidOperation(String.format(Sys.Res.cannotCallBeforeResponse, 'getAllResponseHeaders'));
        }

        return this._headers;
    },

    _onReadyStateChange : function(e)
    {
        if (e.xmlHttp.readyState === 4)
        {
            e.sender._responseAvailable = true;
            e.sender._responseData = e.xmlHttp.responseText;
            e.sender._statusCode = e.xmlHttp.status;
            e.sender._statusText = e.xmlHttp.statusText;
            e.sender._headers = e.xmlHttp.getAllResponseHeaders();

            e.xmlHttp.onreadystatechange = Function.emptyMethod;
            e.sender._onReceiveHandler = null;

            e.sender._started = false;
        }
    }
}

Sys.Net.XMLHttpSyncExecutor.registerClass('Sys.Net.XMLHttpSyncExecutor', Sys.Net.WebRequestExecutor);

if (typeof(Sys) != 'undefined')
{
    Sys.Application.notifyScriptLoaded();
}