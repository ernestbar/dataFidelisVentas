<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="appProyVentas.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsTotal" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="appProyVentas.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter Name="PV_ESTADO" DefaultValue="TODOS" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsFinalizados" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="appProyVentas.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter Name="PV_ESTADO" DefaultValue="FINALIZACION" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPreAprobados" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="appProyVentas.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter Name="PV_ESTADO" DefaultValue="PRE APROBADOS" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCanceladoTotal" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="appProyVentas.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter Name="PV_ESTADO" DefaultValue="CANCELADO TOTAL" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<!-- begin #content -->
		<div id="content" class="content">
     <!-- begin page-header -->
			<h1 class="page-header">Dashboard estado general ventas <small></small></h1>
			<!-- end page-header -->
			<!-- begin row -->
			<div class="row">
				<!-- begin col-3 -->
				  <asp:Repeater ID="Repeater1" DataSourceID="odsTotal" runat="server">
					  <ItemTemplate>
							<div class="col-lg-3 col-md-6">
								<div class="widget widget-stats bg-gradient-teal">
									<div class="stats-icon stats-icon-lg"><i class="fa fa-globe fa-fw"></i></div>
									<div class="stats-content">
										<div class="stats-title">TOTAL SOLICITUDES</div>
										<div class="stats-number"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></div>
										<div class="stats-progress progress">
											<div class="progress-bar" style="width: 100%;"></div>
										</div>
										<div class="stats-desc"><asp:Label ID="Label2" runat="server" Text='<%# "PERIODO: " + Eval("periodo") %>'></asp:Label></div>
									</div>
								</div>
							</div>
					  </ItemTemplate>
					  </asp:Repeater>
				
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<asp:Repeater ID="Repeater2" DataSourceID="odsFinalizados" runat="server">
					  <ItemTemplate>
						  <div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-blue">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-dollar-sign fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">FINALIZADOS</div>
							<div class="stats-number"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></div>
										<div class="stats-progress progress">
											<div class="progress-bar" style="width: 100%;"></div>
										</div>
										<div class="stats-desc"><asp:Label ID="Label2" runat="server" Text='<%# "PERIODO: " + Eval("periodo") %>'></asp:Label></div>
						</div>
					</div>
				</div>
					  </ItemTemplate>
					</asp:Repeater>
				
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<asp:Repeater ID="Repeater3" DataSourceID="odsPreAprobados" runat="server">
					  <ItemTemplate>
						  <div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-purple">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-archive fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">PRE APROBADOS</div>
							<div class="stats-number"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></div>
										<div class="stats-progress progress">
											<div class="progress-bar" style="width: 100%;"></div>
										</div>
										<div class="stats-desc"><asp:Label ID="Label2" runat="server" Text='<%# "PERIODO: " + Eval("periodo") %>'></asp:Label></div>
						</div>
					</div>
				</div>
					  </ItemTemplate>
					</asp:Repeater>
				
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<asp:Repeater ID="Repeater4" DataSourceID="odsCanceladoTotal" runat="server">
					  <ItemTemplate>
						  <div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-black">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-comment-alt fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">CANCELADO TOTAL</div>
							<div class="stats-number"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></div>
										<div class="stats-progress progress">
											<div class="progress-bar" style="width: 100%;"></div>
										</div>
										<div class="stats-desc"><asp:Label ID="Label2" runat="server" Text='<%# "PERIODO: " + Eval("periodo") %>'></asp:Label></div>
						</div>
					</div>
				</div>
					  </ItemTemplate>
					</asp:Repeater>
				
				<!-- end col-3 -->
			</div>
			<!-- end row -->
			<!-- end row -->
			</div>
</asp:Content>
