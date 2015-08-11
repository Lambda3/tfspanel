require('require-dir') 'gulptasks/'
gulp = require 'gulp'


gulp.task 'compile', ['resolve dependencies', 'compile coffee', 'compile less']
gulp.task 'release', ['release dependencies', 'release coffee', 'release less']
gulp.task 'clean', ['clean dependencies', 'clean coffee', 'clean less']
gulp.task 'watch', ['watch coffee', 'watch less']


gulp.task 'default', ['compile', 'watch']
