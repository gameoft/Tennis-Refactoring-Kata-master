/* Copyright © 2016 by Apparound Inc */

module.exports = function(config) 
{
    config.set({
        basePath: '..',
        frameworks: ['jasmine'],
        browserNoActivityTimeout: 1000000,
        files: [
            'TennisGame1.js',
            'TennisGame2.js',
            'TennisGame3.js',
            '__tests__/*.js'
        ],     
        exclude: [],
        reporters: ['progress', 'html'],
        port: 9876,
        colors: true,
        browsers: ['Chrome'],
        singleRun: true,
        htmlReporter: {
            outputFile: '__tests__/reports/index.html'
        }        
    });
};