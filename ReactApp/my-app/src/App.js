import React, {useEffect, useState} from 'react';
import './App.css';
import axios from 'axios';
import {makeStyles} from '@material-ui/core/styles';
import {Table, TableContainer, TableHead, TableCell, TableBody, TableRow, Modal, Button, TextField} from '@material-ui/core';
import {Edit, Delete} from '@material-ui/icons';

const baseUrl="https://localhost:44375/api/FinalClient"

const useStyles = makeStyles((theme) => ({
  modal: {
    position: 'absolute',
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)'
  },
  iconos:{
    cursor: 'pointer'
  }, 
  inputMaterial:{
    width: '100%'
  }
}));

function App() {
const styles= useStyles();
  const [data, setData]=useState([]);
  const [modalInsertar, setModalInsertar]=useState(false);
  const [modalEditar, setModalEditar]=useState(false);
  const [modalEliminar, setModalEliminar]=useState(false);

  const [dataselected, setdataselected]=useState({
    name: '',
    lastName:'',
    billingType: '',
    documentNumber: ''
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setdataselected(dataselected=>({
      ...dataselected,
      [name]: value
    }))
    console.log(dataselected);
  }

  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
    })
  }

  const peticionPost=async()=>{
    await axios.post(baseUrl, dataselected)
    .then(response=>{
      setData(data.concat(response.data))
      abrirCerrarModalInsertar()
    })
  }

  const peticionPut=async()=>{
    await axios.put(baseUrl+dataselected.id, dataselected)
    .then(response=>{
      var dataNueva=data;
      dataNueva.map(data=>{
        if(dataselected.id===data.id){
          data.nombre=dataselected.name;
          data.lanzamiento=dataselected.lastName;
          data.empresa=dataselected.documentNumber;
          data.unidades_vendidas=dataselected.billingType;
        }
      })
      setData(dataNueva);
      abrirCerrarModalEditar();
    })
  }

  const peticionDelete=async()=>{
    await axios.delete(baseUrl+dataselected.id)
    .then(response=>{
      setData(data.filter(data=>data.id!==dataselected.id));
      abrirCerrarModalEliminar();
    })
  }

  const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
  }

  const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrirCerrarModalEliminar=()=>{
    setModalEliminar(!modalEliminar);
  }

  const seleccionardata=(data, caso)=>{
    setdataselected(data);
    (caso==='Editar')?abrirCerrarModalEditar():abrirCerrarModalEliminar()
  }

  useEffect(async()=>{
    await peticionGet();
  },[])

  const bodyInsertar=(
    <div className={styles.modal}>
      <h3>Agregar Nueva data</h3>
      <TextField name="name" className={styles.inputMaterial} label="Nombre" onChange={handleChange}/>
      <br />
      <TextField name="lastName" className={styles.inputMaterial} label="Empresa" onChange={handleChange}/>
      <br />
      <TextField name="billingType" className={styles.inputMaterial} label="Lanzamiento" onChange={handleChange}/>
      <br />
      <TextField name="documentNumber" className={styles.inputMaterial} label="Unidades Vendidas" onChange={handleChange}/>
      <br /><br />
      <div align="right">
        <Button color="primary" onClick={()=>peticionPost()}>Insertar</Button>
        <Button onClick={()=>abrirCerrarModalInsertar()}>Cancelar</Button>
      </div>
    </div>
  )

  const bodyEditar=(
    <div className={styles.modal}>
      <h3>Editar data</h3>
      <TextField name="nombre" className={styles.inputMaterial} label="Nombre" onChange={handleChange} value={dataselected && dataselected.name}/>
      <br />
      <TextField name="empresa" className={styles.inputMaterial} label="Empresa" onChange={handleChange} value={dataselected && dataselected.lastName}/>
      <br />
      <TextField name="lanzamiento" className={styles.inputMaterial} label="Lanzamiento" onChange={handleChange} value={dataselected && dataselected.documentNumber}/>
      <br />
      <TextField name="unidades_vendidas" className={styles.inputMaterial} label="Unidades Vendidas" onChange={handleChange} value={dataselected && dataselected.billingType}/>
      <br /><br />
      <div align="right">
        <Button color="primary" onClick={()=>peticionPut()}>Editar</Button>
        <Button onClick={()=>abrirCerrarModalEditar()}>Cancelar</Button>
      </div>
    </div>
  )

  const bodyEliminar=(
    <div className={styles.modal}>
      <p>Estás seguro que deseas eliminar la data <b>{dataselected && dataselected.nombre}</b> ? </p>
      <div align="right">
        <Button color="secondary" onClick={()=>peticionDelete()} >Sí</Button>
        <Button onClick={()=>abrirCerrarModalEliminar()}>No</Button>

      </div>

    </div>
  )


  return (
    <div className="App">
      <br />
    <Button onClick={()=>abrirCerrarModalInsertar()}>Insertar</Button>
      <br /><br />
     <TableContainer>
       <Table>
         <TableHead>
           <TableRow>
             <TableCell>Nombre</TableCell>
             <TableCell>Empresa</TableCell>
             <TableCell>Año de Lanzamiento</TableCell>
             <TableCell>Unidades Vendidas (millones)</TableCell>
             <TableCell>Acciones</TableCell>
           </TableRow>
         </TableHead>

         <TableBody>
           {data.map(data=>(
             <TableRow key={data.id}>
               <TableCell>{data.name}</TableCell>
               <TableCell>{data.lastName}</TableCell>
               <TableCell>{data.documentNumber}</TableCell>
               <TableCell>{data.billingType}</TableCell>
               <TableCell>
                 <Edit className={styles.iconos} onClick={()=>seleccionardata(data, 'Editar')}/>
                 &nbsp;&nbsp;&nbsp;
                 <Delete  className={styles.iconos} onClick={()=>seleccionardata(data, 'Eliminar')}/>
                 </TableCell>
             </TableRow>
           ))}
         </TableBody>
       </Table>
     </TableContainer>
     
     <Modal
     open={modalInsertar}
     onClose={abrirCerrarModalInsertar}>
        {bodyInsertar}
     </Modal>

     <Modal
     open={modalEditar}
     onClose={abrirCerrarModalEditar}>
        {bodyEditar}
     </Modal>

     <Modal
     open={modalEliminar}
     onClose={abrirCerrarModalEliminar}>
        {bodyEliminar}
     </Modal>
    </div>
  );
}

export default App;