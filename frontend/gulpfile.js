var {src, dest, series, parallel} = require('gulp');
var log = require('fancy-log');

function cleanTask(cb){
    log('Cleaning...');
    cb();
}

function jsTask(cb){
    log('Running js task!');
    cb();
}

function cssTask(cb){
    log('Running css task!');
    log('sdfa')
    
    cb();
}



exports.clean = cleanTask;
exports.build = parallel(jsTask, cssTask);
exports.rebuild = series(
    cleanTask,
    parallel(jsTask, cssTask)
)
// the default task is build task
exports.default = parallel(jsTask, cssTask);