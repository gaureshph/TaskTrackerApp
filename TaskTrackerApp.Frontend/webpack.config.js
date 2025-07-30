const path = require("path");
const fs = require("fs");
const dotenv = require("dotenv");
const webpack = require('webpack');

const HtmlWebpackPlugin = require("html-webpack-plugin");

const isDev = process.env.NODE_ENV !== 'production';

let env = {};
if (isDev && fs.existsSync('.env')) {
  env = dotenv.config().parsed || {};
}

env = {
  ...process.env,
  ...env,
};

const appEnv = {
  'process.env.API_BASE_URL': JSON.stringify(env.API_BASE_URL),
};

module.exports = {
  entry: "./src/index.js",
  output: {
    path: path.resolve(__dirname, "dist"),
    filename: "bundle.js",
    clean: true,
    publicPath: '/'
  },
  module: {
    rules: [
      {
        test: /\.css$/i, // For .css files
        use: ["style-loader", "css-loader"],
      },
      {
        test: /\.(js|jsx)$/, // handles both .js and .jsx
        exclude: /node_modules/,
        use: "babel-loader",
      },
    ],
  },
  resolve: {
    extensions: [".js", ".jsx"], // so you can import without extension
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: "./public/index.html",
    }),
    new webpack.DefinePlugin(appEnv),
  ],
  devServer: {
    static: "./dist",
    port: 3000,
    hot: true,
    historyApiFallback: true,
  },
  mode: "development",
};
