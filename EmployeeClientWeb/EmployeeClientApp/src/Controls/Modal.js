import React from 'react';
import EditEmployee from '../Component/EditEmployee';

const Modal = (props) => {

  return (
    <>
      <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">{props.ModalTitle}</h5>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={()=>{
                 document.getElementById("error").style.display="none";
                 document.getElementById("success").style.display="none";
              }}></button>
            </div>
            <div class="modal-body">
              <EditEmployee {...props} />
            </div>
            <div class="modal-footer">
              <div id="success" style={{display:'none'}} class="alert alert-success" role="alert">                  
              </div>
              <div id="error" style={{display:'none'}} class="alert alert-danger" role="alert">
              </div>
            </div>
          </div>
        </div>
      </div>

    </>
  );
}

export default Modal;