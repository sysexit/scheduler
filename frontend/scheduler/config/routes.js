const path = require('path');
const express = require('express');

let app = express();
const publicPath = path.resolve(__dirname, '../public');

app.use(express.static(publicPath));

app.get('*', (req, res) => {
  res.sendFile(path.resolve(__dirname, '../public', 'index.html'));
});

module.exports = app;
