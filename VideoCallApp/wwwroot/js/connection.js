  let container = document.getElementById("call_container");
   
   document.addEventListener('DOMContentLoaded', () => {
       container.style.opacity = "1";
   }); 
   
  
function StartCall() {
    let idleImg = document.getElementById("img_idle");
    let webcam = document.getElementById("webcam");
    idleImg.style.opacity = 0;
    if (navigator.mediaDevices.getUserMedia) {

        navigator.mediaDevices.getUserMedia({ video: true }).
            then(function (stream) {
                webcam.srcObject = stream;

            }
            );
    }
    else
        console.log("Can't use your webcam");

}
   async function call()
   {

       const configuration = {'iceServers': [{'urls': 'stun:stun.l.google.com:19302'}]}
       const peerConnection = new RTCPeerConnection(configuration);
       signalingChannel.addEventListener('message', async message => {
           if (message.answer) {
               const remoteDesc = new RTCSessionDescription(message.answer);
               await peerConnection.setRemoteDescription(remoteDesc);
           }
       });
       const offer = await peerConnection.createOffer();
       await peerConnection.setLocalDescription(offer);
       signalingChannel.send({'offer': offer});
   }
  const peerConnection = new RTCPeerConnection(configuration);
  signalingChannel.addEventListener('message', async message => {
      if (message.offer) {
          peerConnection.setRemoteDescription(new RTCSessionDescription(message.offer));
          const answer = await peerConnection.createAnswer();
          await peerConnection.setLocalDescription(answer);
          signalingChannel.send({'answer': answer});
      }
  });