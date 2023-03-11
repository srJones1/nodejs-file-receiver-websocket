# nodejs-file-receiver-websocket

Simple file receiver as stream

## steps

- node >= 14
- npm install
- npm run start

## send file

Just open a socket to http://localhost:3000 and send the file as **audio** event

javascript client sample:

```
socket.emit('audio', ...);
```