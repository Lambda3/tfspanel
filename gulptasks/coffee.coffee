sourcemaps = require 'gulp-sourcemaps'
coffeelint = require 'gulp-coffeelint'
plumber = require 'gulp-plumber'
coffee = require 'gulp-coffee'
uglify = require 'gulp-uglify'
watch = require 'gulp-watch'
size = require 'gulp-size'
gulp = require 'gulp'
del = require 'del'


path =
  coffee: 'wwwroot/coffee/*.coffee'
  js: 'wwwroot/js/'

compile = (stream) ->
  stream.pipe do plumber
    .pipe do coffeelint
    .pipe do coffeelint.reporter
    .pipe do sourcemaps.init
    .pipe coffee bare: true
    .pipe do sourcemaps.write
    .pipe gulp.dest path.js


gulp.task 'compile coffee', ->
  stream = gulp.src path.coffee
  compile stream
  return stream

gulp.task 'release coffee', ->
  gulp.src path.coffee
    .pipe do plumber
    .pipe do coffeelint
    .pipe do coffeelint.reporter
    .pipe do coffee
    .pipe do uglify
    .pipe size showFiles: true
    .pipe gulp.dest path.js


gulp.task 'watch coffee', ->
  stream = gulp.src path.coffee, verbose: true
    .pipe watch path.coffee

  compile stream
  return stream

gulp.task 'clean coffee', ->
  del [path.js]
