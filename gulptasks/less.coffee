autoprefixer = require 'gulp-autoprefixer'
sourcemaps = require 'gulp-sourcemaps'
minify = require 'gulp-minify-css'
plumber = require 'gulp-plumber'
watch = require 'gulp-watch'
less = require 'gulp-less'
size = require 'gulp-size'
gulp = require 'gulp'
del = require 'del'


path =
  file: 'src/less/site.less'
  less: 'src/less/*.less'
  css: 'src/css/'


gulp.task 'compile less', ->
  gulp.src path.file
    .pipe do plumber
    .pipe do sourcemaps.init
    .pipe do less
    .pipe do autoprefixer
    .pipe do sourcemaps.write
    .pipe gulp.dest path.css


gulp.task 'release less', ->
  gulp.src path.less
    .pipe do plumber
    .pipe do less
    .pipe do autoprefixer
    .pipe minify keepSpecialComments: 0
    .pipe size showFiles: true
    .pipe gulp.dest path.css


gulp.task 'watch less', ->
  gulp.watch path.less, ['compile less']


gulp.task 'clean less', ->
  del [path.css]
