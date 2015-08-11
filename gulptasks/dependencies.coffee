minify = require 'gulp-minify-css'
size = require 'gulp-size'
gulp = require 'gulp'
del = require 'del'


path = 'src/lib/'


gulp.task 'resolve dependencies', ->
  gulp.src 'node_modules/normalize-css/normalize.css'
    .pipe gulp.dest path


gulp.task 'release dependencies', ->
  gulp.src 'node_modules/normalize-css/normalize.css'
    .pipe minify keepSpecialComments: 0
    .pipe size showFiles: true
    .pipe gulp.dest path

gulp.task 'clean dependencies', ->
  del [path]
