function executeFunctionByName(ns, name)
{
    if(typeof ns === "string"){
        ns = document.querySelector(ns);
    }
    var args = Array.prototype.slice.call(arguments).splice(2);
    if(!ns || !ns[name]){
        console.error(`"Blazor attempted to call ${ns}.${name}(${args.join(', ')})`)
        return;
    }
    return ns[name].apply(ns, args);
}

function registerBlazorCustomHandler(component, eventName, callbackClass, callBackMethodName) {
    component.addEventListener(eventName, (e) => {
        callbackClass.invokeMethodAsync(callBackMethodName, e.detail);
    });
}

function setWebComponentProperty(webComp, propertyName, value) {
    webComp[propertyName] = value;
}