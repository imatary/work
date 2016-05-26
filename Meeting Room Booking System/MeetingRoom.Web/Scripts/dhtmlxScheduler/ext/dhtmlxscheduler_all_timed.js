/*
@license
dhtmlxScheduler.Net v.3.3.17 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e.config.all_timed="short";var t=function(e){return!((e.end_date-e.start_date)/36e5>=24)};e._safe_copy=function(t){var i=null,a=null;return t.event_pid&&(i=e.getEvent(t.event_pid)),i&&i.isPrototypeOf(t)?(a=e._copy_event(t),delete a.event_length,delete a.event_pid,delete a.rec_pattern,delete a.rec_type):a=e._lame_clone(t),a};var i=e._pre_render_events_line;e._pre_render_events_line=function(a,s){function n(e){var t=r(e.start_date);return+e.end_date>+t}function r(t){
var i=e.date.add(t,1,"day");return i=e.date.date_part(i)}function d(t,i){var a=e.date.date_part(new Date(t));return a.setHours(i),a}if(!this.config.all_timed)return i.call(this,a,s);for(var o=0;o<a.length;o++){var l=a[o];if(!l._timed)if("short"!=this.config.all_timed||t(l)){var _=this._safe_copy(l);_.start_date=new Date(_.start_date),n(l)?(_.end_date=r(_.start_date),24!=this.config.last_hour&&(_.end_date=d(_.start_date,this.config.last_hour))):_.end_date=new Date(l.end_date);var h=!1;_.start_date<this._max_date&&_.end_date>this._min_date&&_.start_date<_.end_date&&(a[o]=_,
h=!0);var c=this._safe_copy(l);if(c.end_date=new Date(c.end_date),c.start_date=c.start_date<this._min_date?d(this._min_date,this.config.first_hour):d(r(l.start_date),this.config.first_hour),c.start_date<this._max_date&&c.start_date<c.end_date){if(!h){a[o--]=c;continue}a.splice(o+1,0,c)}}else a.splice(o--,1)}var u="move"==this._drag_mode?!1:s;return i.call(this,a,u)};var a=e.get_visible_events;e.get_visible_events=function(e){return this.config.all_timed&&this.config.multi_day?a.call(this,!1):a.call(this,e);

},e.attachEvent("onBeforeViewChange",function(t,i,a,s){return e._allow_dnd="day"==a||"week"==a,!0}),e._is_main_area_event=function(e){return!!(e._timed||this.config.all_timed===!0||"short"==this.config.all_timed&&t(e))};var s=e.updateEvent;e.updateEvent=function(t){var i,a=e.config.all_timed&&!(e.isOneDayEvent(e._events[t])||e.getState().drag_id);a&&(i=e.config.update_render,e.config.update_render=!0),s.apply(e,arguments),a&&(e.config.update_render=i)}}()});