const { src, dest, series, parallel } = require('gulp');
const copy = require('gulp-copy');
const log = require('fancy-log');

function cleanTask(cb) {
    log('Cleaning...');
    cb(); 
}

function jsTask(cb) {
    log('Running js task!');
    cb();
}

function cssTask(cb) {
    log('Running css task!');
    log('sdfa')    
    cb();
}

function copyTexts() {
    let csrc = ['src/**/*.txt'];
    let cdest = 'output';
    let options = { prefix: 2 };
    log('Copying files from ' + csrc + ' to output');
    return src(csrc)
        .pipe(copy(cdest, options));
}

exports.clean = cleanTask;
exports.build = parallel(jsTask, cssTask)
exports.rebuild = series(
    cleanTask,
    parallel(jsTask, cssTask)
);
// the default task is build task
exports.copy = copyTexts;