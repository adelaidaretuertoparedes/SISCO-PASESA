/**
 * @author: @Hugo Cacha
 */

module.exports = {
    rootJsFolder: "./src/js/",
    app: {
        allTsFiles: "../src/app/**/*.ts"
    },
    webpack: require('./config/webpack.dev')({ env: 'development' }),
    rootCssFolder: "./src/assets/css",
    rootBowerFolder:"./src/assets/bower",
    rootMaterialSass:"./src/material-sass",
    rootFontsFolder:"./src/assets/fonts"
};