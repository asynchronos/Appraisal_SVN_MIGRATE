function clsAjax(){
   
	this.ajax;
	this.url;
	this.method;
	this.param;
	this.responseText;
	this.function_name;
	
	//Create Ajax Object
	this.create = function(){
		this.param = new Array();
		if(window.ActiveXObject){
			this.ajax = new ActiveXObject("Microsoft.XMLHTTP");
		}else{
			this.ajax = new XMLHttpRequest();
		}
	}

	this.addParam = function(name, value){
		this.param.push(name+"="+encodeURI(value));
	}

	this.createParameters = function(){
		var q = "";
		if(this.param.length > 0){
			for(i=0; i<this.param.length; i++){
				q += this.param[i]+"&";
			}
			q = q.substr(0, q.length-1);
		}
		return q;
	}

	//Send data
	this.send = function(){
		var tempurl = this.url;
		var querystring = this.createParameters();
		if(this.method.toLowerCase() == "get"){
			tempurl += "?"+querystring;
		}
		this.ajax.onreadystatechange = this.stateChange;		
		this.ajax.open(this.method, tempurl, true);
		if(this.method.toLowerCase()=="post"){
			this.ajax.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
			this.ajax.send(querystring);
		}else{
			this.ajax.send(null);
		}
	}

	//Check state change and retrieve data.
	var self = this;
	this.stateChange = function(){
		if(self.ajax!=null){
			if(self.ajax.readyState == 4){				
				if(self.ajax.status == 200){
					self.responseText = self.ajax.responseText;
					if(self.function_name != ""){						
						eval(self.function_name);
					}
				}
			}
		}else{
			alert("Ajax object not set.");
		}
	}
}


 // ***** ********   วิธีการใช้  ใช้ code ดังนี้
 var obj = new clsAjax();
 function testajax(){
	document.getElementById('dv').innerHTML = "loading...";
	obj.create();
	obj.url = "test.asp";
	obj.method = document.getElementById('selMethod').value;  // post,get
	obj.addParam("data", document.getElementById('data').value);
	obj.addParam("data2", document.getElementById('data2').value);
	obj.function_name = "testdata()";	// function ที่ให้ส่งไปกรณ๊สำเร็จ
	obj.send();
}
 // ********** ชื่อฟังชั่นหลังจากการที่ส่งข้อมูล
 function testdata(){
     document.getElementById('dv').innerHTML = obj.responseText;
  
}

