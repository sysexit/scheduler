const path = require('path')
const CopyWebpackPlugin = require('copy-webpack-plugin')
const { DefinePlugin } = require('webpack');

const ROOT_DIRECTORY = path.resolve(__dirname, '..')
const SRC_DIRECTORY = path.resolve(ROOT_DIRECTORY, 'src', 'scheduler-app')
const BUILD_DIRECTORY = path.resolve(ROOT_DIRECTORY, 'public', 'build')
const NODEM_DIRECTORY = path.resolve(ROOT_DIRECTORY, 'node_modules');
const APP_PATH = path.resolve(ROOT_DIRECTORY, 'src', 'scheduler-app', 'index.js');

const config = {
  entry: APP_PATH,
  output: {
    path: BUILD_DIRECTORY,
    filename: 'bundle.js',
    publicPath: '/'
  },
  mode: 'development',
  performance: {
    hints: false
  },
  plugins: [
    new CopyWebpackPlugin(
      {
        patterns: [
          { from: path.join(SRC_DIRECTORY, 'assets'), to: BUILD_DIRECTORY }
        ]
      }
    ),
    new DefinePlugin({
      'process.env.API_URL': JSON.stringify('http://api.domain.com'),
      'process.env.DOMAIN': JSON.stringify('domain.com')
    })
  ],
  module: {
    rules: [
      { test: /\.js$/, exclude: NODEM_DIRECTORY, loader: 'babel-loader' },
      {
        test: /\.scss$/,
        use: [
          {
            loader: 'file-loader',
            options: { outputPath: 'css/', name: '[name].min.css' }
          },
          'sass-loader'
        ]
      },
      {
        test: /\.(png|svg|jpg|gif|pdf)$/,
        use: [
          'file-loader'
        ]
      }
    ]
  },
  resolve: {
    extensions: ['.js', '.scss'],
    alias: {
      "scheduler-app": SRC_DIRECTORY
    },
  },
}

module.exports = config
