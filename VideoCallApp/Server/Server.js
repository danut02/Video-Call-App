const express = require('express');
const http = require('http');
const socketIO = require('socket.io');
const cors = require('cors');
const app = express();
const server = http.createServer(app);
const io = socketIO(server);
const { createProxyMiddleware } = require('http-proxy-middleware');
app.use(express.static('public'));



app.use('/socket.io', createProxyMiddleware({ target: 'http://localhost:7176', ws: true }));

io.on('connection', (socket) => {
    console.log('A user connected');

    socket.on('offer', (offer) => {
        socket.broadcast.emit('offer', offer);
    });

    socket.on('answer', (answer) => {
        socket.broadcast.emit('answer', answer);
    });

    socket.on('candidate', (candidate) => {
        socket.broadcast.emit('candidate', candidate);
    });

    socket.on('disconnect', () => {
        console.log('User disconnected');
    });
});
server.listen(7176, () => {
    console.log('Server is running on port 7176');
});