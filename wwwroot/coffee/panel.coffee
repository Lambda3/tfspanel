ready = (handler) ->
  if document.readyState != 'loading'
    do handler
  else
    document.addEventListener 'DOMContentLoaded', handler

get = (url, success, error) ->
  request = new XMLHttpRequest
  request.open 'GET', url, true

  request.onload = ->
    if this.status >= 200 && this.status < 400
      success JSON.parse this.response
    else
      do error

  request.onerror = error
  do request.send

intervalInSeconds = 60
templates = new Templates

loadBuilds = (builds) ->
  buildList = document.querySelector 'section.builds > ul'
  newHTML = templates.builds builds

  if newHTML != buildList.innerHTML
    buildList.innerHTML = newHTML

loadPullRequests = (prs) ->
  prList = document.querySelector 'section.pull-requests > ul'
  newHTML = templates.pullRequests prs

  if newHTML != prList.innerHTML
    prList.innerHTML = newHTML

update = ->
  get '/api/builds', loadBuilds
  get '/api/pullrequests', loadPullRequests

ready ->
  do update
  window.setInterval update, intervalInSeconds * 1000