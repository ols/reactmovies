var Spinner = React.createClass({
    render: function () {
        return (
            <div>
                <i className="fa fa-spinner fa-pulse fa-3x fa-fw margin-bottom"></i>
            </div>
        );
    }
});

var Movie = React.createClass({
    render: function () {
        return (
            <div className="movie col-xs-3">
                <div>
                    <a href={this.props.urlimdb}>
                        <img className="movieImg" alt={this.props.title} src={this.props.urlposter}/>
                    </a>
                </div>
            </div>
        );
    }
});

var MovieList = React.createClass({
    render: function () {
        var movieNodes = this.props.data.map(function (movie) {
            return (
                <Movie title={movie.Title} urlposter={movie.UrlPoster} urlimdb={movie.UrlIMDB}>
                </Movie>
            );
        });
        return (
            <div className="movieList row">
                {movieNodes}
            </div>
        );
    }
});

var MovieForm = React.createClass({
    handleSubmit: function (e) {
        e.preventDefault();
        var title = this.refs.title.getDOMNode().value.trim();
        if (!title) {
            return;
        }
        this.props.onMovieSearch({ Title: title });
        return;
    },
    render: function() {
        return (
          <form className="movieForm" onSubmit={this.handleSubmit}>
            <input type="text" ref="title" className="form-control" placeholder="Search for movie" />
            <input type="submit" className="btn btn-default" value="Search" />
          </form>
      );
    }
});

var MovieBox = React.createClass({
    getInitialState: function() {
        return {
            data: [],
            spinning: false
        };
    },
    loadTopMoviesFromServer: function () {
        this.setState({ spinning: true });
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.setState({ data: data.Movies, spinning: false });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    componentWillMount: function () {
        this.loadTopMoviesFromServer();
    },
    handleMovieSearch: function (movie) {
        this.setState({ spinning: true, data: [] });
        $.ajax({
            url: this.props.submitUrl + "?title=" + movie.Title,
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.setState({ data: data.Movies, spinning: false });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    render: function() {
        return (
            <div className="movieBox">
                <div>
                    <h1 className="movieBoxh1">Movies</h1>
                    <MovieForm onMovieSearch={this.handleMovieSearch} />
                    <MovieList data={this.state.data} />
                </div>
                {
                    this.state.spinning ? <Spinner /> : false
                }
            </div>
        );
    }
});

ReactDOM.render(
    <MovieBox url="/matrixmovies" submitUrl="/moviebyname" />,
    document.getElementById('content')
);
