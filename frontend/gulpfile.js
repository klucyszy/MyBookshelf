var util = require('gulp-util');

function defaultTask(cb){
    util.log('Running default gulp Task!')
    cb();
}

exports.default = defaultTask;