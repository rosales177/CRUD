document.addEventListener('DOMContentLoaded', function () {
  
  function getHtmlTable() {
    let selectSexo = document.getElementById('select-sexo');
    fetch(`/Trabajador?sexo=${selectSexo.value}`,{method:'GET'})
    .then(response => response.text())
    .then(data => {
      document.getElementById('container-table').innerHTML = data
      makeActions();
    }).catch(error => {
      console.log(error);
    })
  }

  function openModal() {
    let modal = document.getElementById('modal-editor');
    if(modal.style.opacity==0){
      modal.style.opacity = 1;
      modal.style.visibility='visible';
    }else{
      modal.style.opacity = 0;
      modal.style.visibility='hidden';
    }
    resetForm();
  }

  function getForm(){
    fetch('/Trabajador/Modal',{method:'GET'})
    .then(response => response.text())
    .then(data => {
      let bodyModal = document.getElementById('body-modal');
      bodyModal.innerHTML = data
      document.getElementById('form-trabajador').addEventListener('submit',save);
      getDepartamentos();
      document.getElementById('btn-reset').addEventListener('click', ()=>{
        resetForm();
        openModal();
      });
      
    }).catch(error => {
      console.log(error);
    })
  }

  function getDepartamentos(){
    fetch('/Departamento',{method:'GET'})
    .then(response => response.text())
    .then(data => {
      document.getElementById('select-departamento').innerHTML = data
      getProvincias();
      document.getElementById('list-departamento').addEventListener('change',getProvincias);
    }).catch(error => {
      console.log(error);
    })
  }

  function getProvincias(){
    let departamento = document.getElementById('list-departamento');
    fetch(`/Provincia?departamento=${departamento.value}`,{method:'GET'})
    .then(response => response.text())
    .then(data => {
      document.getElementById('select-provincia').innerHTML = data
      getDistritos();
      document.getElementById('list-provincia').addEventListener('change',getDistritos);
    }).catch(error => {
      console.log(error);
    })
  }

  function getDistritos(){
    let provincia = document.getElementById('list-provincia');
    fetch(`/Distrito?provincia=${provincia.value}`,{method:'GET'})
    .then(response => response.text())
    .then(data => {
      document.getElementById('select-distrito').innerHTML = data
    }).catch(error => {
      console.log(error);
    })
  }

  function resetForm(){
    let titleForm = document.getElementById('title-form');
      titleForm.innerText = "Creación de Trabajador";
    let form = document.getElementById('form-trabajador');
    form.querySelector('[name="IdTrabajador"').value = "";
    form.querySelector('[name="TipoDocumento"]').value = "DNI";
    form.querySelector('[name="NroDocumento"]').value = "";
    form.querySelector('[name="Nombres"]').value = "";
    form.querySelector('[name="IdDepartamento"]').value = "";
    getProvincias();
    form.querySelector('[name="IdProvincia"]').value = "";
    getDistritos();
    form.querySelector('[name="IdDistrito"]').value = "";
  }

  function getDataTrabajador(e){
    openModal();
    let id = e.target.parentNode.parentNode.parentNode.getAttribute('data-id');
    let formData = JSON.stringify({
      IdTrabajador: id
    });

    fetch('/Trabajador/GetTrabajador',{
      method:'POST',
      body: formData,
      headers:{
        'Content-Type': 'application/json'
      }
    }).then(response => response.json())
    .then(data => {
      let titleForm = document.getElementById('title-form');
      titleForm.innerText = "Actualización de Trabajador";
      let form = document.getElementById('form-trabajador');
      form.querySelector('[name="IdTrabajador"').value = data.trabajador.idTrabajador;
      form.querySelector('[name="TipoDocumento"]').value = data.trabajador.tipoDocumento;
      form.querySelector('[name="NroDocumento"]').value = data.trabajador.nroDocumento;
      form.querySelector('[name="Nombres"]').value = data.trabajador.nombres;
      let sexoCheckbox = form.querySelector(`[name="Sexo"][value="${data.trabajador.sexo}"]`);
      if (sexoCheckbox) {
          sexoCheckbox.checked = true;
      }
      form.querySelector('[name="IdDepartamento"]').value = data.departamento.idDepartamento;
      form.querySelector('[name="IdProvincia"]').value = data.provincia.idProvincia;
      form.querySelector('[name="IdDistrito"]').value = data.trabajador.idDistrito;

      getProvincias()
      getDistritos()
    }).catch(error => {
      console.log(error);
    });

  }
  

  function save(e){
    e.preventDefault();
    let alert=document.getElementById('alert');
    let form = document.getElementById('form-trabajador');
    let idTrabajador = form.querySelector('[name="IdTrabajador"]').value;

    if(form.querySelector('[name="TipoDocumento"]').value.trim() === '' ||
    form.querySelector('[name="NroDocumento"]').value.trim() === '' || 
    form.querySelector('[name="Nombres"]').value.trim() === '' ||
    form.querySelector('[name="IdDistrito"]').value.trim() === ''){
      let alert_message="Los campos Tipo Documento, Nro. Documento, Distrito y Nombres son obligatorios";
      alert.classList.remove('d-none');
      document.getElementById('content-alert').innerHTML = alert_message;
      openModal();
      return;
    }
    let formData = {
      TipoDocumento: form.querySelector('[name="TipoDocumento"]').value,
      NroDocumento: form.querySelector('[name="NroDocumento"]').value,
      Nombres: form.querySelector('[name="Nombres"]').value,
      Sexo: form.querySelector('[name="Sexo"]:checked').value,
      IdDistrito: form.querySelector('[name="IdDistrito"]').value
    };
    let url = '/Trabajador/AddTrabajador';
    if(idTrabajador !== ""){
      url = '/Trabajador/UpdateTrabajador';
      formData.IdTrabajador = idTrabajador;
    }
    
    fetch(url,{
      method:'POST',
      body:JSON.stringify(formData),
      headers:{
        'Content-Type': 'application/json'
      }
    }).then(response => response.text())
    .then(data => {
      openModal();
      getHtmlTable();
    }).catch(error => {
      console.log(error);
    })
  }

  function delete_(e){

    let id = e.target.parentNode.parentNode.parentNode.getAttribute('data-id');
    let formData = JSON.stringify({
      IdTrabajador: id
    })

    let confirmation = new Promise((resolve, reject) => { 
      resolve(window.confirm("¿Deseas eliminar este registro?"))
    });
    confirmation.then((result) => {
      if(result){
        fetch('/Trabajador/DeleteTrabajador',{
          method:'POST',
          body:formData,
          headers:{
            'Content-Type': 'application/json'
          }
        }).then(response => response.text())
        .then(data => {
          getHtmlTable();
        }).catch(error => {
          console.log(error);
        });
      }
    });
  }

  function makeActions(){
    document.querySelectorAll('.btn-edit').forEach(element => {
      element.addEventListener('click',getDataTrabajador);
    });
    document.querySelectorAll('.btn-delete').forEach(element => {
      element.addEventListener('click',delete_);
    });
  }

  getHtmlTable();
  getForm();
  

  document.getElementById('select-sexo').addEventListener('change', getHtmlTable);
  document.getElementById('btn-add').addEventListener('click', openModal);
  document.getElementById('btn-close').addEventListener('click', openModal);
  document.getElementById('btn-close-alert').addEventListener('click', ()=>{
    let alert=document.getElementById('alert');
    alert.classList.add('d-none');
  })
  

})