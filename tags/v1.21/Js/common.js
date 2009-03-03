var ns4 = (document.layers)? true:false;
var ie4 = (document.all)? true:false;

//function for get element by id
function e(id,obj) {
    if(!obj)obj=this;
    
    var result = null;
    
    try{
        result = obj.document.getElementById(id);
    }catch(err){
        alert("Can't find id " + id);
        result = false;
    }
    
    return result;
}

//function for get elements by name
function arrayE(name,obj){
    if(!obj)obj=this;
    return document.getElementsByName(name);
}
//show hide elements object
function showHide(divId){
    var visibility = null;
    if (ns4) {
        if((visibility = e(divId).style.visibility) == "show") 
	        e(divId).style.visibility = "hide";
        else if(visibility == "hide" ) 
	        e(divId).style.visibility = "show";
    }else {
        if((visibility = e(divId).style.visibility) == "visible") 
	        e(divId).style.visibility = "hidden";
        else if(visibility == "hidden")
	        e(divId).style.visibility = "visible";
    }
}
//show elements object
function show(divId) {
    if (ns4) e(divId).style.visibility = "show";
    else e(divId).style.visibility = "visible";
}
//hide elements object
function hide(divId) {
    if (ns4) e(divId).style.visibility = "hide";
    else e(divId).style.visibility = "hidden";
}

// <summary>
// find value in query string by key
// </summmary>
// <param name="key" type="string">key of query string</param>
function getValueFromQueryString(key){
    //new array
    var result = new Array("No Query String","No Query String");
    
    //search get ?key1=value1&key2=value2&...
    //substring get key1=value1&key2=value2&...
    var queryStr = window.location.search.substring(1);

    if (queryStr!=undefined){
        //split value to array 
        //ex key1=value1,key2=value2,...
        var queryArray = queryStr.split("&");
        
        for(i=0;i<queryArray.length;i++){
            if(queryArray[i].indexOf(key) >= 0){
                //key1,value1
                result = queryArray[i].split("=");
                break;
            }
        }
    }

    return result[1];
}

//copy any value to clipboard
function copy2Clipboard(id){
    window.clipboardData.setData('Text' , e(id).innerHTML);
    return false;
// get the clipboard data
//var emailText = window.clipboardData.getData('Text');

//clear clipboard data
//window.clipboardData.clearData();
}

// <summary>
// use for set value
// </summmary>
// <param name="dom" type="dom">dom element to set value</param>
// <param name="value" type="string">value to set</param>
function setDomValue(dom,value){
    if (!dom) return false;
    
    dom.value = value;
}

// <summary>
// use for set value with old value
// </summmary>
// <param name="dom" type="dom">dom element to set value</param>
// <param name="value" type="string">value to set</param>
// <param name="seperate" type="string">ตัวคั่นระหว่างคำ</param>
function setDomValueWithOldValue(dom,value,seperate){
    if (!dom) return false;
    
    if (!seperate) seperate="";
    dom.value = dom.value + seperate + value;
}

// <summary>
// use for set value
// <param name="domId" type="string">id of dom element to set value</param>
// <param name="value" type="string">value to set</param>
function setDomValueById(domId,value){
    setValueToDOM(e(domId),value);
}

// <summary>
// use for get value
// </summmary>
// <param name="dom" type="dom">dom element to get value</param>
// <param name="value" type="string">value to get</param>
function getDomValue(dom){
    if (!dom) return false;

    var result = null;
    
    elemNodeName = dom.nodeName.toLowerCase();
    
	if (elemNodeName == "input"
	|| elemNodeName == "select"
	|| elemNodeName == "option"
	|| elemNodeName == "textarea") {
		result = dom.value;
	} else {
		result = dom.innerHTML;
	}
    
    return result;
}

// <summary>
// use for get value
// <param name="domId" type="string">id of dom element to get value</param>
// <param name="value" type="string">value to get</param>
function getDomValueById(domId){
    return getDomValue(e(domId));
}

function mapDropdown2TextboxById(dropdownId,textboxId){
    if (!e(dropdownId) || !e(textboxId)) return false;
    
    mapDropdown2Textbox(e(dropdownId),e(textboxId));
}

function mapDropdown2Textbox(dropdownObj,textboxObj){
    if (!dropdownObj || !textboxObj) return false;
    
    textboxObj.value = dropdownObj.options[dropdownObj.selectedIndex].value;
    
    //show hide textbox
    if (textboxObj.value == "เรื่องอื่นๆ"){
        textboxObj.value = "";
        if (ns4) textboxObj.style.visibility = "show";
        else textboxObj.style.visibility = "visible";
    }else{
        if (ns4) textboxObj.style.visibility = "hide";
        else textboxObj.style.visibility = "hidden";
    }
}
