var xmlHttp = createXmlHttpRequestObject();

function createcreateXmlHttpRequestObject() {
    var xmlHttp;

    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    } else {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlHttp.open()
    xmlHttp.onreadystatechanged = function () {
        if (xmlHttp.readyState == 1) {
            //ignored by google chrome
            console.log("Status 1: server connection established.");
        }

        if (xmlHttp.readyState == 2) {
            console.log("Status 2: server recieved request.");
        }

        if (xmlHttp.readyState == 3) {
            console.log("Status 3: server processing request.");
        }

        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                //success
                try {
                    text = xmlHttp.responseText;
                    console.log("Status 4: request finished and response is ready. " + text);
                } catch (e) {
                    alert(e.toString());
                }
            } else {
                //something went wrong
                alert(xmlHttp.statusText);
            }
        }
    };

    return xmlHttp;
}