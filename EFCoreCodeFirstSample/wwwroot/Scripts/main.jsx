import React from "react";
import master from './Components/MasterPage/master';

class CommentBox extends React.Component {
    render() {
        return (
            <master>
            </master>
        );
    }
}

ReactDOM.render(<CommentBox />, document.getElementById('content'));