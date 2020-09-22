var alarmTime = new Date();

function upClicked() {
    alarmTime.setSeconds(alarmTime.getSeconds() + 1);
    document.getElementById("alarmTime").innerHTML = alarmTime.toLocaleTimeString();
    var sp = alarmTime.toLocaleTimeString('en-GB').split(':');
    var alarmTimeSeconds = (+sp[0]) * 60 * 60 + (+sp[1]) * 60 + (+sp[2]);
    document.cookie = "alarmtime000=" + alarmTimeSeconds;
}

function downClicked() {
    alarmTime.setSeconds(alarmTime.getSeconds() - 1);
    document.getElementById("alarmTime").innerHTML = alarmTime.toLocaleTimeString();
    var sp = alarmTime.toLocaleTimeString('en-GB').split(':');
    var alarmTimeSeconds = (+sp[0]) * 60 * 60 + (+sp[1]) * 60 + (+sp[2]);
    document.cookie = "alarmtime000=" + alarmTimeSeconds;
}

function onloadTimer() {
    var curTime = new Date().toLocaleTimeString();
    alarmTime = new Date();
    setInterval(setCurTime, 1000);
    document.getElementById("curTime").innerHTML = curTime.toString('it-IT');
    document.getElementById("alarmTime").innerHTML = curTime.toString('it-IT');
}

function setCurTime() {
    var curTime = new Date().toLocaleTimeString();
    document.getElementById("curTime").innerHTML = curTime.toString('it-IT');
}

var alarmId;

function startAlarm(alarm) {
    alarmId = alarm.id;
    //CODE FROM STACK OVERFLOW TO RETREIVE COOKIE BASED OFF OF VARIABLE SUBMITTED
    var match = document.cookie.match(new RegExp('(^| )' + alarmId + '=([^;]+)'));
    if (match) {
        var v1 = (match[2]).indexOf("=");
        var v2 = (match[2]).indexOf("&");
        var alarmTimeString = (match[2]).substring(v1 + 1, v2);
        var alarmTime = parseInt(alarmTimeString);
    }

    var curTime = new Date().toLocaleTimeString('en-GB');
    //CODE FROM STACK OVERFLOW TO SEPERATE STRING BY COLONS AND MULTIPLY THE SECTIONS BY THEIR VALUE IN SECONDS
    var sp = curTime.split(':');
    var curTimeSeconds = (+sp[0]) * 60 * 60 + (+sp[1]) * 60 + (+sp[2]);

    if (curTimeSeconds > alarmTime) {
        var timeTillAlarm = (86400 - (curTimeSeconds - alarmTime)) * 1000;
    } else if (curTimeSeconds < alarmTime) {
        var timeTillAlarm = (alarmTime - curTimeSeconds) * 1000;
    }
    
    var timer = setTimeout(alarmReached, timeTillAlarm);
}

function deleteAlarm(alarm) {
    alarmId = alarm.id;
    PageMethods.deleteAlarm(alarmId);
    alert("Please Refresh the Page to see changes.");
}


function alarmReached() {

    var match = document.cookie.match(new RegExp('(^| )' + alarmId + '=([^;]+)'));

    if (match) {
        var v1 = (match[2]).indexOf("alarmSound");
        var alarmSoundString = (match[2]).substring(v1 + 11);
    }
    PageMethods.playSound(alarmSoundString);
}


function returnAlarm() {
    return alarmTime.getSeconds();
}

function alertBox(infoString) {
    var frag = document.createDocumentFragment();
    var temp = document.createElement('div');
    temp.innerHTML = infoString;
    while (temp.firstChild) {
        frag.appendChild(temp.firstChild);
    }
    return frag;
}