function createElement(tag, id, attrs, data) {
    const el = document.createElement(tag);
    attrs = attrs || {};
    data = data || {};
    el.setAttribute("id", id);
    for (const attr in attrs) {
        el.setAttribute(attr, attrs[attr]);
    }
    for (const k in data) {
        el[k] = data[k];
    }
    document.body.appendChild(el);
}

function removeElement(el) {
    if (typeof el === "string") {
        el = document.getElementById(el);
    }
    if (el) {
        el.remove();
    }
}

function executeFunctionByName(ns, name) {
    if (typeof ns === "string") {
        ns = document.getElementById(ns);
    }
    var args = Array.prototype.slice.call(arguments).splice(2);
    if (!ns || !ns[name]) {
        console.error(`"Blazor attempted to call ${ns}.${name}(${args.join(', ')})`)
        return;
    }
    return ns[name].apply(ns, args);
}

function registerBlazorCustomHandler(component, eventName, callbackClass, callBackMethodName) {
    if (typeof component === "string") {
        component = document.getElementById(component);
    }
    
    component.addEventListener(eventName, (e) => {
        callbackClass.invokeMethodAsync(callBackMethodName, e.detail);
    });
}

function setWebComponentProperty(webComp, propertyName, value) {
    webComp[propertyName] = value;
}