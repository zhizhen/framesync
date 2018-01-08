-module(server_app).

-behaviour(application).

%% Application callbacks
-export([start/0]).
-export([start/2, stop/1]).

%% ===================================================================
%% Application callbacks
%% ===================================================================

start() ->
    server_app:start([], []).

start(_StartType, _StartArgs) ->
    server_sup:start_link().

stop(_State) ->
    ok.
