  let container = document.getElementById("call_container");
   
   document.addEventListener('DOMContentLoaded', () => {
       container.style.opacity = "1";
   }); 
   
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