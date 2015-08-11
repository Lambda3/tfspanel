class Templates
  _buildTemplate: (status, icon, build) ->
    return "<li class=\"#{icon} #{status}\">
          <h1>#{build.name}<span>#{build.number}</span></h1>
          <ul>
            <li>Date:<strong>#{build.date}</strong></li>
            <li>Running time:<strong>#{build.duration}</strong></li>
            <li>Author:<strong>#{build.author}</strong></li>
          </ul>
        </li>".replace(/ +(?= )/g, '')

  _pullrequest: (pr) ->
    return "<li>
          <h1>#{pr.title}</h1>
          <ul>
            <li>Repository:<strong>#{pr.repo}</strong></li>
            <li>From:<strong>#{pr.from}</strong></li>
            <li>To:<strong>#{pr.to}</strong></li>
          </ul>
        </li>".replace(/ +(?= )/g, '')

  _build: (build) =>
    status = build.status.toLowerCase()

    if status == 'failed'
      return @_buildTemplate status, 'fa-times', build

    if status == 'succeeded'
      return @_buildTemplate status, 'fa-check', build

    return @_buildTemplate 'partially-succeeded', 'fa-exclamation', build

  builds: (builds) =>
    return (this._build(b) for b in builds).join ''

  pullRequests: (prs) =>
    return (this._pullrequest(p) for p in prs).join ''
