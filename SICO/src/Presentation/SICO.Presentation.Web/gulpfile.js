/**
 * @author: @Hugo Cacha
 */
var WebpackDevServer = require("webpack-dev-server");
var gulp = require('gulp');
var gulpUtil = require('gulp-util');
//var runSeq = require('run-sequence');
var webpack = require('webpack');
var concat = require("gulp-concat");
var cssnano = require('gulp-cssnano');
var gulpIf = require('gulp-if');
var gulp = require('gulp');
var sass = require('gulp-sass');
var sassGlob = require('gulp-sass-glob');
var moduleImporter =require('sass-module-importer');
var path=require('path');

//var cfg = {
//    _dir: './config',
//    webpack: require('./config/webpack.dev')
//};

var buildConfig = require('./gulp.config');
var isRelease = false;
if (process.env.NODE_ENV && process.env.NODE_ENV === 'production') {
    isRelease = true;
}
var port_server = 8085;

//dev task:
gulp.task('server-dev', ['copy-bower-fonts-to-assets','copy-bower-components-to-assets','bundle-css-vendor-assets'], function () {
    //Webpackdev server builds so there's no need
    var compiler = webpack(buildConfig.webpack);

    new WebpackDevServer(compiler, {
        noInfo: true
    }).listen(port_server, "localhost", function (err) {
        if (err) throw new gulpUtil.PluginError("webpack-dev-server", err);
        // Server listening
        console.log("Listening at http://localhost:" + port_server);
    });
});

//bundle css vendor
gulp.task('bundle-css-vendor-assets',['bundle-sass-to-css-vendor'], function () {
    var cssName = "vendor"+(isRelease?".min":"")+".css";
        
    gulp.src(["./src/custom-material-theme.css",
            "./node_modules/ng2-flex-layout/dist/ng2-flex-layout.css",
            "./node_modules/ag-grid/dist/styles/ag-grid.css",
            "./node_modules/ag-grid/dist/styles/theme-material.css",
            "./bower_components/font-awesome/css/font-awesome.css"
            ])
       .pipe(gulpIf(isRelease,cssnano({ zindex: false })))
       .pipe(concat(cssName))
       .pipe(gulp.dest(buildConfig.rootCssFolder));
});

//bundle css vendor
gulp.task('copy-bower-components-to-assets', function () {           
    gulp.src(["./bower_components/polymer/*.{html,js}",
            "./bower_components/vaadin-grid/**/*.{html,js,svg}"            
            ],{ "base" : "./bower_components" })       
       .pipe(gulp.dest(buildConfig.rootBowerFolder));
});

//copy material sass
gulp.task('copy-material-sass', function () {           
    gulp.src(["./node_modules/@angular/material/**/*.scss"                        
            ])       
       .pipe(gulp.dest(buildConfig.rootMaterialSass));
});

//compile custom material theme
gulp.task('bundle-sass-to-css-vendor',['copy-material-sass'], function () {
  return gulp.src('./src/custom-material-theme.scss')
    //.pipe(sassGlob())
    .pipe(sass())
    //.pipe(sass.sync().on('error', sass.logError))
    .pipe(gulp.dest('./src'));
}); 

gulp.task('copy-bower-fonts-to-assets', function () {
    gulp.src(['./bower_components/font-awesome/fonts/*.{woff2,ttf,woff,eof,svg}'])
    .pipe(gulp.dest(buildConfig.rootFontsFolder));
});

gulp.task('default', function () {
    // place code for your default task here
}); 