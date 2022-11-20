<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="solicitudes_admin.aspx.cs" Inherits="appProyVentas.solicitudes_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_SEG_GET_CLIENTES" TypeName="appProyVentas.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoCortina" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="TIPO CORTINA" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsOpcion" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="OPCION" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoTelaCortina" runat="server" SelectMethod="PR_SEG_GET_TELA_CORTINA" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlTipoCortina" Name="CLI_TIPO_CORTINA" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoCenefa" runat="server" SelectMethod="PR_SEG_GET_CENEFA" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlTipoCortina" Name="CLI_TIPO_CORTINA" Type="String" />
			<asp:ControlParameter ControlID="ddlTipoTelaCortina" Name="CLI_TIPO_TELA_CORTINA" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<%--<asp:ObjectDataSource ID="odsContactosCliente" runat="server" SelectMethod="PR_PAR_GET_MEDIOS_CONTACTO_CLIENTE" TypeName="appRRHHadmin.Clases.Medios_contratos">
		<SelectParameters>
            <asp:ControlParameter ControlID="ddlClienteFiltro" Name="PV_ID_CLIENTE" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>--%>
	
	<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<!-- begin #content -->
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn-sm btn-info btn-block" OnClick="btnNuevo_Click" runat="server" Text="Nuevo solicitud" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrar Solicitudes<small></small></h1>
											<asp:RadioButtonList ID="rblTipoSolicitud" CssClass="form-control" OnSelectedIndexChanged="rblTipoSolicitud_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">
												<asp:ListItem Text="ACTUALES" Value="ACTUALES" Selected="True"></asp:ListItem>
												<asp:ListItem Text="HISTORICOS" Value="HISTORICOS"></asp:ListItem>
											</asp:RadioButtonList>
											<%--<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">color</th>
															<th class="text-nowrap">RRAZON SOCIAL</th>
															<th class="text-nowrap">SOLICITUD</th>
															<th class="text-nowrap">CONTACTO</th>
															<th class="text-nowrap">TELEFONO</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-nowrap">UBICACION</th>
															<th class="text-nowrap">FECHA SOLICITU</th>
															<th class="text-nowrap">FECHA ENTREGA</th>
															<th class="text-nowrap">ETAPA ACTUAL</th>
															<th class="text-nowrap">OPERADOR</th>
															<th class="text-nowrap">MONTO TOTAL</th>
															<th class="text-nowrap">DESCUENTO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Image ID="Image1" Height="20px" runat="server" ImageUrl='<%# @"COLORES\" + Eval("COLOR") +  ".PNG" %>' /></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CLI_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("SOLICITUD") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("contacto") %>'></asp:Label></td>
															<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("telefono") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("correoelectronico") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("ubicacion") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("fecha_solicitud") %>'></asp:Label></td>
																<td><asp:Label ID="Label32" runat="server" Text='<%# Eval("fecha_entrega") %>'></asp:Label></td>
																<td><asp:Label ID="Label42" runat="server" Text='<%# Eval("etapa_actual") %>'></asp:Label></td>
																<td><asp:Label ID="Label62" runat="server" Text='<%# Eval("operador") %>'></asp:Label></td>
																<td><asp:Label ID="Label621" runat="server" Text='<%# Eval("monto_total") %>'></asp:Label></td>
																<td><asp:Label ID="Label612" runat="server" Text='<%# Eval("descuento") %>'></asp:Label></td>
															<td>
															<%--	<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Eliminar" ToolTip="Borrar registro" />--%>
                                                                
																<asp:Button ID="btnEtapas" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SOLICITUD") %>' OnClick="btnEtapas_Click1" runat="server" Text="Ver etapas" ToolTip="Ver etapas" />
															</td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Solicitud</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cliente:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlCliente" class="form-control col-md-6"  DataSourceID="odsClientesTodos" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Contacto:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtContacto" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtContacto" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Telefono:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTelefono" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Email:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
						<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ubicacion:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtUbicacion" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Comentarios:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtComentarios" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->

					<div style="border:solid">
						<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos items</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ubicacion ventana:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtUbicacionVentana" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtUbicacionVentana" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo cortina:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlTipoCortina" AutoPostBack="true" class="form-control col-md-12"  DataSourceID="odsTipoCortina" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoCortina_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="items" ForeColor="Red" ControlToValidate="ddlTipoCortina" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo tela cortina:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlTipoTelaCortina" AutoPostBack="true" class="form-control col-md-12"  DataSourceID="odsTipoTelaCortina" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoTelaCortina_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="items" ForeColor="Red" ControlToValidate="ddlTipoTelaCortina" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Alto:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtAlto" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtAlto" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ancho:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtAncho" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtAncho" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
			<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo cenefa:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlTipoCenefa" class="form-control col-md-12"  DataSourceID="odsTipoCenefa" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoCenefa_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ValidationGroup="items" ForeColor="Red" ControlToValidate="ddlTipoCenefa" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Es cenefa madera?:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlEsMadera" AutoPostBack="true" class="form-control col-md-12"  DataSourceID="odsOpcion" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Es encajonada?:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlEsEncajonada" AutoPostBack="true" class="form-control col-md-12"  DataSourceID="odsOpcion" DataTextField="descripcion" DataValueField="codigo"  runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cantidad panos:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtCantidadPanos" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtCantidadPanos" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Observaciones:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtObservaciones" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Monto total:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtMontoTotal" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtMontoTotal" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>--%>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Desccuento:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtDescuento" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ValidationGroup="items" ControlToValidate="txtDescuento" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>--%>
						
					<!-- end form-group row -->
						<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label"></label>
						<div class="col-md-6">
							<asp:Button ID="btnAgregarItem" CssClass="btn btn-success"  runat="server" CausesValidation="true" ValidationGroup="items" OnClick="btnAgregarItem_Click" Text="Agregar" />
						</div>
					</div>
						
					<!-- end form-group row -->
						<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label"></label>
						<div class="col-md-6">
							<asp:ListBox ID="lbItems" CssClass="form-control col-md-12" runat="server"></asp:ListBox>
						</div>
					</div>
						
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							
						</div>
					</div>
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			<div class="col-md-6">
			<asp:Button ID="btnVolverSolicitud" class="btn-sm btn-info btn-block" OnClick="btnVolverSolicitud_Click" runat="server" Text="Volver solicitud" />
			</div>
										<!-- begin page-header -->
											<h1 class="page-header">ETAPAS SOLICITUD<small></small></h1>
											
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<sdiv class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">SOLICITUD</th>
															<th class="text-nowrap">ETAPA</th>
															<th class="text-nowrap">OPERADOR</th>
															<th class="text-nowrap">FECHA DESDE</th>
															<th class="text-nowrap">FECHA HASTA</th>
															<th class="text-nowrap">COMENTARIOS</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("solicitud") %>'></asp:Label></td>
																<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("etapa") %>'></asp:Label></td>
																<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("operador_etapa") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("fecha_desde") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("fecha_hasta") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("comentarios") %>'></asp:Label></td>
																<td>
																<asp:Button ID="btnCancelar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnCancelar_Click" runat="server" Text="Cancelar" ToolTip="Cancelar etapa" />
																<asp:Button ID="btnAprobar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnAprobar_Click"  runat="server" Text="Aprobar" ToolTip="Aprobar etapa" />
																<asp:Button ID="btnEnviar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnEnviar_Click" runat="server" Text="Enviar" ToolTip="Envia correo con el PDF" />
																<asp:Button ID="btnGenerar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("solicitud") +"|"+ Eval("id_etapa") %>' OnClick="btnGenerar_Click" runat="server" Text="Generar" ToolTip="Generar PDF" />
																	<asp:Button ID="btnEtapasDetalle" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnEtapasDetalle_Click" runat="server" Text="Detalles" ToolTip="Detalles de la etapa" />
																</td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</sdiv>
										</div>
		</asp:View>
		<asp:View ID="View4" runat="server">
				<div class="col-md-6">
			<asp:Button ID="btnVolverEtapas" class="btn-sm btn-info btn-block" OnClick="btnVolverEtapas_Click" runat="server" Text="Volver a etapas" />
			</div>
			
										<!-- begin page-header -->
											<h1 class="page-header">ETAPAS DETALLES<small></small></h1>
											
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<sdiv class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">SOLICITUD</th>
															<th class="text-nowrap">TIPO CORTINA</th>
															<th class="text-nowrap">TELA</th>
															<th class="text-nowrap">ALTO</th>
															<th class="text-nowrap">ANCHO</th>
															<th class="text-nowrap">CENEFA</th>
															<th class="text-nowrap">ES CENEFA MADERA</th>
															<th class="text-nowrap">ES ENCAJONADA</th>
															<th class="text-nowrap">CANTIDAD DE PANOS</th>
															<th class="text-nowrap">OBSERVACION</th>
															<th class="text-nowrap">PRECIO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater3"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("solicitud") %>'></asp:Label></td>
																<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("tipo_cortina") %>'></asp:Label></td>
																<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("tela") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("alto") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("ancho") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("cenefa") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("es_cenefa_madera") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("es_encajonada") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("cantidad_panos") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("observacion") %>'></asp:Label></td>
																<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("precio") %>'></asp:Label></td>
																<td>
																	
																	<%--<asp:Button ID="btnCancelar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnCancelar_Click" runat="server" Text="Cancelar" ToolTip="Cancelar etapa" />
																	<asp:Button ID="btnAprobar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnAprobar_Click"  runat="server" Text="Aprobar" ToolTip="Aprobar etapa" />
																	<asp:Button ID="btnEnviar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnEnviar_Click" runat="server" Text="Enviar" ToolTip="Envia correo con el PDF" />
																	<asp:Button ID="btnGenerar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnGenerar_Click" runat="server" Text="Generar" ToolTip="Generar PDF" />
																	<asp:Button ID="btnEtapasDetalle" class="btn btn-success btn-sm" CommandArgument='<%# Eval("id_etapa") %>' OnClick="btnEtapasDetalle_Click" runat="server" Text="Detalles" ToolTip="Detalles --%>de la etapa" />
																</td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</sdiv>
										</div>
			</asp:View>
		<asp:View ID="View5" runat="server">
			<asp:HiddenField ID="hfDiv" runat="server" />
			<div class="col-md-6">
			<asp:Button ID="btnVolverEtapasCotizacion" class="btn-sm btn-info btn-block" OnClick="btnVolverEtapasCotizacion_Click" runat="server" Text="Volver a etapas" />
				<asp:Button ID="btnExportarPDF"  OnClientClick="exportPDF()" class="btn btn-info btn-block" CausesValidation="false" Visible="true"  runat="server" Text="Exportar a PDF" />
			<asp:Button ID="btnEnviarCorreo" OnClick="btnEnviarCorreo_Click" OnClientClick="copiar()" class="btn btn-info btn-block"  runat="server" Text="Enviar Email" />
			</div>
			
			<div id="invoice" style="font-size:small">
				
			
										<!-- begin page-header -->
											<h1 class="page-header">ETAPAS DETALLES<small></small></h1>
											
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<table>
													<tr>
														<th>
															<table>
																<tr>
																	<th>
																		ID
																	</th>
																	<th>
																		<asp:Label ID="lblID" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		Cliente:
																	</th>
																	<th>
																		<asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		NIT/CI:
																	</th>
																	<th>
																		<asp:Label ID="lblNitCi" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		Celular:
																	</th>
																	<th>
																		<asp:Label ID="lblCelular" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
															</table>
														</th>
														<th>

															<table>
																<tr>
																	<th>
																		Nro:
																	</th>
																	<th>
																		<asp:Label ID="lblNro" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		Fecha cotizacion:
																	</th>
																	<th>
																		<asp:Label ID="lblFechaCot" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		Cotizacion valida hasta:
																	</th>
																	<th>
																		<asp:Label ID="lblFechaCotHasta" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
																<tr>
																	<th>
																		Tiempode produccion (dias):
																	</th>
																	<th>
																		<asp:Label ID="lblTiempoProd" runat="server" Text=""></asp:Label>
																	</th>
																</tr>
															</table>

														</th>
														<th>
															<img src="assets/img/logo/LOGO_VENTAS.jpg" height="60" width="200" />
														</th>
													</tr>
													<tr>
														<th>
															NOTA
														</th>
														
													</tr>

												</table>
												<!-- end panel-heading -->
												
												<sdiv class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table" style="font-size:xx-small" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">ITEM</th>
															<th class="text-nowrap">TIPO CORTINA</th>
															<th class="text-nowrap">TELA</th>
															<th class="text-nowrap">UBICACION</th>
															<th class="text-nowrap">ALTO  MTS</th>
															<th class="text-nowrap">ANCHO MTS</th>
															<th class="text-nowrap">CENEFA</th>
															<th class="text-nowrap">NUMERO DE PAÑOS</th>
															<th class="text-nowrap">PRECIO UNITARIO</th>
															<th class="text-nowrap">CANTIDAD MTS</th>
															<th class="text-nowrap">MONTO TOTAL BS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater4"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("id") %>'></asp:Label></td>
																<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("tipo_cortina") %>'></asp:Label></td>
																<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("tela") %>'></asp:Label></td>
																<td><asp:Label ID="Label7" runat="server" Text='<%# Eval("ubicacion") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("alto_mts") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("ancho_mts") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("cenefa") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("numero_panos") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("precio_unitario_mts") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("cantidad_mts") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("monto_total_bs") %>'></asp:Label></td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</sdiv>
										</div>
			</div>
		</asp:View>
		
    </asp:MultiView>
			
			
		</div>
		<!-- end #content -->

	 <script>

         const options = {
             pagebreak: { after: ['.Card'] },
             margin: 0.5,
             filename: 'reserva.pdf',
             image: {
                 type: 'jpeg',
                 quality: 500
             },
             html2canvas: { scale: 1, y: 0, scrollY: 0 },
             jsPDF: {
                 unit: 'in',
                 format: 'letter',
                 orientation: 'landscape'
             }
         }

         $('.btn-download').click(function (e) {
             e.preventDefault();
             const element = document.getElementById('invoice');
             html2pdf().from(element).set(options).save();
         });

         function exportPDF() {
             const element = document.getElementById('invoice');
             html2pdf().from(element).set(options).save();
             printDiv('invoice');
         }

         function exportPDF2() {
             const element = document.getElementById('invoice2');
             html2pdf().from(element).set(options).save();
             printDiv('invoice2');
         }

         function printDiv(divName) {
             var printContents = document.getElementById(divName).innerHTML;
             var originalContents = document.body.innerHTML;
             document.body.innerHTML = printContents;
             //window.print();
             document.body.innerHTML = originalContents;
         }

     </script>
	<script type="text/javascript">
        function copiar() {
            // Crea un input para poder copiar el texto dentro       
            let copyText = document.getElementById('invoice1').innerHTML
            const textArea = document.createElement('textarea');
            textArea.textContent = copyText;
            document.body.append(textArea);
            textArea.select();
            document.execCommand("copy");
            document.getElementById('<%=hfDiv.ClientID%>').value = textArea.textContent;
            // Delete created Element       
            textArea.remove()
        }

    </script>     
</asp:Content>
