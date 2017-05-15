var testCEF = function() {
	alert("Hello from from Javascript!");
}

var onLoadHandler = function() {
	chartViewer.browserLoaded().then(function (res)
	{
	   alert("eventHandler");
	});
}



