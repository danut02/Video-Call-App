const container = document.getElementById("call_container");
const idleImg = document.getElementById("img_idle");
const localVideo = document.getElementById('webcam');
const remoteVideo = document.getElementById('other_user');
const socket = io('http://localhost:7176');
const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] };
let localStream;
let peerConnection;
let microhpone = document.getElementsByClassName("b3 bi-mic")[0];
let bool_mic = false;

document.addEventListener('DOMContentLoaded', () => {
    container.style.opacity = "1";
});

socket.on('offer', async (offer) => {
    await handleOffer(offer);
});

socket.on('answer', async (answer) => {
    await handleAnswer(answer);
});

socket.on('candidate', async (candidate) => {
    await handleCandidate(candidate);
});

function mic_on() {
    bool_mic = !bool_mic;

    if (bool_mic) {
        microhpone.style.backgroundColor = "green";
        microhpone.style.color = "black";
    }
    else {
        microhpone.style.backgroundColor = "red";
        microhpone.style.color = "white";
    }
};

async function StartCall() {
    idleImg.style.opacity = 0;
    try {
        localStream = await navigator.mediaDevices.getUserMedia({ video: true, audio: true });
        localVideo.srcObject = localStream;
        if (!peerConnection) {
            peerConnection = createPeerConnection();
            localStream.getTracks().forEach(track => peerConnection.addTrack(track, localStream));
            const offer = await peerConnection.createOffer();
            await peerConnection.setLocalDescription(offer);
            socket.emit('offer', offer);
        } else {
            console.error('Peer connection already exists.');
        }
    } catch (error) {
        console.error('Error accessing media devices:', error);
    }
}

function createPeerConnection() {
    const pc = new RTCPeerConnection(configuration);

    pc.onicecandidate = (event) => {
        if (event.candidate) {
            socket.emit('candidate', event.candidate);
        }
    };

    pc.ontrack = (event) => {
        remoteVideo.srcObject = event.streams[0];
    };

    return pc;
}

async function handleOffer(offer) {
    if (!peerConnection) {
        peerConnection = createPeerConnection();
    }
    await peerConnection.setRemoteDescription(new RTCSessionDescription(offer));
    localStream.getTracks().forEach(track => peerConnection.addTrack(track, localStream));

    const answer = await peerConnection.createAnswer();
    await peerConnection.setLocalDescription(answer);
    socket.emit('answer', answer);
}

async function handleAnswer(answer) {
    await peerConnection.setRemoteDescription(new RTCSessionDescription(answer));
}

async function handleCandidate(candidate) {
    try {
        if (peerConnection) {
            await peerConnection.addIceCandidate(new RTCIceCandidate(candidate));
        } else {
            console.error('Peer connection not available.');
        }
    } catch (e) {
        console.error('Error adding received ice candidate:', e);
    }
}

function EndCall() {
    idleImg.style.opacity = 1;
    if (peerConnection) {
        peerConnection.close();
        peerConnection = null;
        localVideo.srcObject = null;
    }
}