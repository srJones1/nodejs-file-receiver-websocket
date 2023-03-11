const express = require('express');
const fs = require('fs')
const path = require('path')
const app = express()
const server = require('http').Server(app)
const io = require('socket.io')(server,{maxHttpBufferSize: 1e7})

io.on('connection', function (socket) {
  socket.on('audio', async function (msg) {
      var date = new Date(msg.timeMillis);
      await fs.promises.writeFile(path.join(__dirname, "videos", `${date.toString()}.wav`), msg.data, "binary");         
  });
});

server.listen(3000)
