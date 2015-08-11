ready = (handler) ->
  if document.readyState != 'loading'
    do handler
  else
    document.addEventListener 'DOMContentLoaded', handler

singleEl = (selector) ->
  document.querySelector selector

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

intervalInSeconds = 10
templates = new Templates

loadBuilds = (builds) ->
  buildList = singleEl 'section.builds > ul'
  newHTML = templates.builds builds

  if newHTML != buildList.innerHTML
    buildList.innerHTML = newHTML

loadPullRequests = (prs) ->
  prList = singleEl 'section.pull-requests > ul'
  newHTML = templates.pullRequests prs

  if newHTML != prList.innerHTML
    prList.innerHTML = newHTML

update = ->
  get '/builds', loadBuilds
  get '/pullrequests', loadPullRequests

ready ->
  do update
  window.setInterval update, intervalInSeconds * 1000
