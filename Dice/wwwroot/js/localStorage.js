window.localStorageHelper = {
    get: function (key) {
        return localStorage.getItem(key);
    },
    set: function (key, value) {
        localStorage.setItem(key, value);
    }
};


window.sessionStorageHelper = {
    set: function (key, value) {
        const json = JSON.stringify(value);
        const encodedValue = btoa(unescape(encodeURIComponent(json)));
        sessionStorage.setItem(key, encodedValue);
    },
    get: function (key) {
        const encodedValue = sessionStorage.getItem(key);
        if (!encodedValue) return null;
        const json = decodeURIComponent(escape(atob(encodedValue)));
        return JSON.parse(json);
    }
};

