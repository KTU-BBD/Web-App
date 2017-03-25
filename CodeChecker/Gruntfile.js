module.exports = function(grunt) {
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-sass");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-contrib-concat");

    grunt.initConfig({
        config: {
            APP_PATH: "src/assets/app",
            JS_DEPLOY_PATH: "Scripts",
            CSS_DEPLOY_PATH: "Content",
            FONT_DEPLOY_PATH: "Content/fonts",
            VENDOR_PATH: "bower_components",
            SCSS_ASSET_PATH: "Assets/Scss",
            JS_ASSET_PATH: "Assets/Angular"
        },
        concat: {
            jsDepepndencies: {
                files: {
                    "<%= config.JS_DEPLOY_PATH  %>/plugins.js": [
                        "<%= config.VENDOR_PATH  %>/angular/angular.js"
                    ]
                }
            },
            cssDependencies: {
                files: {
                    "<%= config.CSS_DEPLOY_PATH  %>/plugins.css": [
                        "<%= config.VENDOR_PATH  %>/bootstrap/dist/css/bootstrap.min.css",
                        "<%= config.VENDOR_PATH  %>/bootstrap/dist/css/bootstrap-theme.min.css",
                        "<%= config.VENDOR_PATH  %>/font-awesome/css/font-awesome.min.css"
                    ]
                }
            }
        },
        sass: {
            dist: {
                options: {
                    style: "expanded"
                },
                files: {
                    "<%= config.CSS_DEPLOY_PATH %>/styles.css": "<%= config.SCSS_ASSET_PATH %>/styles.scss"
                }
            }
        },
        copy: {
            fa_fonts: {
                cwd: "<%= config.VENDOR_PATH  %>/font-awesome/fonts/",
                src: "**/*",
                dest: "<%= config.FONT_DEPLOY_PATH  %>",
                expand: true
            },
            bs_fonts: {
                cwd: "<%= config.VENDOR_PATH  %>/bootstrap/fonts/",
                src: "**/*",
                dest: "<%= config.FONT_DEPLOY_PATH  %>",
                expand: true
            }
        },
        watch: {
            compileCss: { files: "<%= config.SCSS_ASSET_PATH %>/**/*.scss", tasks: ["sass"] }
        }
    });
    grunt.registerTask("init", ["concat", "copy", "sass"]);
    grunt.registerTask("default", ["watch:compileCss"]);
};