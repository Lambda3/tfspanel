handlebars = require 'express-handlebars'
path = require 'path'

express = require 'express'
app = do express


views = path.join __dirname, 'views'

images = path.join __dirname, 'images'
lib = path.join __dirname, 'lib'
css = path.join __dirname, 'css'
js = path.join __dirname, 'js'

app.engine '.hbs', handlebars extname: '.hbs'
app.set 'view engine', '.hbs'

app.set 'views', views

app.use '/images', express.static images
app.use '/lib', express.static lib
app.use '/css', express.static css
app.use '/js', express.static js

app.get '/', (request, response) -> response.render 'index', team_project: 'SDK'

app.get '/builds', (request, response) ->
  response.json [
    { number: 123465432, name: 'CI SDK', author: 'João da Silva', status: 'Failed', date: 'a minute ago', duration: 7 }
    { number: 123465432, name: 'CI INSTALLER', author: 'João da Silva', status: 'Failed', date: '5 minutes ago', duration: 17.3 }
    { number: 123465432, name: 'CI CONTROLS', author: 'João da Silva', status: 'Partially Succeeded', date: '12/12/2015 18:30', duration: 22.8 }
    { number: 123465432, name: 'CI DOCS', author: 'João da Silva', status: 'Succeeded', date: '12/12/2015 19:36', duration: 2 }
    { number: 123465432, name: 'DEPLOY DOCS', author: 'João da Silva', status: 'Succeeded', date: '12/12/2015 19:30', duration: 5 }
    { number: 123465432, name: 'CI CONTROLS', author: 'João da Silva', status: 'Partially Succeeded', date: '11/12/2015 12:40', duration: 22.8 }
  ]

app.get '/pullrequests', (request, response) ->
  response.json [
    { repo: 'components', from: 'js/menu', to: 'master', title: 'Create menu component' }
  ]

server = app.listen 3000
